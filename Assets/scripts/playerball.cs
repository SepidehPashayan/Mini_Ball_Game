using UnityEngine;
using UnityEngine.UIElements;

public class playerball : MonoBehaviour
{
    [Header("Player Settings")]
    public float speed = 10f;
    private Rigidbody rb;

    [Header("Audio")]
    public AudioSource pickupAudio;
    public AudioSource gameAudio;
    public AudioSource waterAudio;
    public AudioSource winAudio;
    public AudioSource carAudio;

    [Header("Score Settings")]
    private int score = 0;
    private int totalPickups = 140; 

    private ProgressBar scoreBarmain;
    private Label scorelabel;

    private UIDocument scoreUI;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameAudio.Play();

        // گرفتن UIDocument از صحنه
        scoreUI = GetComponent<UIDocument>();
        if (scoreUI == null)
        {
            Debug.LogError("❌ UIDocument به playerball وصل نشده!");
            return;
        }

        // گرفتن عناصر از UXML
        var root = scoreUI.rootVisualElement;
        scoreBarmain = root.Q<ProgressBar>("scoreBarmain");
        scorelabel = root.Q<Label>("scorelabel");

        // بررسی اینکه المان‌ها پیدا شدن یا نه
        if (scoreBarmain == null)
            Debug.LogError("❌ ProgressBar با نام 'scoreBarmain' پیدا نشد!");
        if (scorelabel == null)
            Debug.LogError("❌ Label با نام 'scorelabel' پیدا نشد!");

        // مقداردهی اولیه
        if (scoreBarmain != null)
        {
            scoreBarmain.highValue = totalPickups;
            scoreBarmain.value = 0;
        }

        UpdateScore(); // مقدار اولیه UI
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(-moveHorizontal, 0.0f, -moveVertical);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("pickup item"))
        {
            other.gameObject.SetActive(false);
            pickupAudio.Play();

            score++;
            UpdateScore();
        }
        else if (other.CompareTag("water"))
        {
            waterAudio.Play();
        }
        else if (other.CompareTag("wall"))
        {
            winAudio.Play();
            WinGame();
        }
        else if (other.CompareTag("car"))
        {
            carAudio.Play();
        }
    }

    void UpdateScore()
    {


        if (scorelabel != null)
            scorelabel.text = $"Score: {score} / {totalPickups}";

        //if (scoreBarmain != null)
        scoreBarmain.value = score;
        //scoreBarmain.title = score.ToString();
        scoreBarmain.title = $"Score: {score} / {totalPickups}" ;
    }


    public UIDocument winUI;
    private VisualElement winPanel;

    void WinGame(){
        var root = winUI.rootVisualElement;

        winPanel = root.Q<VisualElement>("winpanel");
        winPanel.style.display = DisplayStyle.Flex; 
    }
    
    public UIDocument loseUI;
    private VisualElement losePanel;

    public void loseGame(){
        var root = loseUI.rootVisualElement;

        losePanel = root.Q<VisualElement>("winpanel");
        losePanel.style.display = DisplayStyle.Flex; 
    }
}

