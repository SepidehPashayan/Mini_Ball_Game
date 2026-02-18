using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RestartGame : MonoBehaviour
{
    [Header("Settings")]
    public float fallDistance = 3f;            // فاصله سقوط قبل از ریست
    public float delayBeforeRestart = 1.0f;    // تاخیر قبل از ریست
    public AudioSource restartAudio;           // صدای شکست

    private float lastGroundY;
    private bool isRestarting = false;         // جلوگیری از چند بار اجرا

    void Start()
    {
        lastGroundY = transform.position.y;
    }

    void Update()
    {
        if (isRestarting) return; // اگر Coroutine در حال اجراست، کاری نکن

        // پیدا کردن ارتفاع زمین زیر توپ
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit))
        {
            lastGroundY = hit.point.y;
        }

        float distanceFromGround = transform.position.y - lastGroundY;

        // اگر توپ پایین‌تر از حد مشخص رفت
        if (distanceFromGround < -fallDistance)
        {
            StartCoroutine(RestartWithDelay());
        }
    }


    public playerball lose;
    private IEnumerator RestartWithDelay()
    {
        isRestarting = true;
        lose.loseGame();
        // پخش صدای شکست
        if (restartAudio != null)
            restartAudio.Play();

        // صبر به اندازه تاخیر تعیین شده
        yield return new WaitForSeconds(delayBeforeRestart);

        // ریست Scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

