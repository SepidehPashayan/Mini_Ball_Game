using UnityEngine;

public class cameraClass : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    public float rotationSpeed = 5f;
    public float minYAngle = -20f;
    public float maxYAngle = 60f;

    private float currentX = 0f;
    private float currentY = 0f;

    private playerball playerScript;


    void Start()
    {
        offset = transform.position - player.transform.position;
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        playerScript = player.GetComponent<playerball>();
    }

    void Update()
    {
        // if (playerScript.loseState) return;
        
        currentX += Input.GetAxis("Mouse X") * rotationSpeed;
        currentY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        currentY = Mathf.Clamp(currentY, minYAngle, maxYAngle);

        Vector3 camPosition = player.transform.position + offset;

        transform.position = camPosition;

        //// کنترل زوم با اسکرول موس
        //float scroll = Input.GetAxis("Mouse ScrollWheel");
        //if (Camera.main.orthographic)
        //{
        //    Camera.main.orthographicSize -= scroll * 5f;
        //    Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, 2f, 10f);
        //}
        //else
        //{
        //    Camera.main.fieldOfView -= scroll * 20f;
        //    Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 30f, 80f);
        //}
    }

    void LateUpdate()
    {
        // if (playerScript.loseState) return;

        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        Vector3 desiredPosition = player.transform.position + rotation * offset;
        transform.position = desiredPosition;
        transform.LookAt(player.transform);
    }

    // تابعی برای برگردوندن جهت فعلی دوربین
    public Quaternion GetCameraRotation()
    {
        return Quaternion.Euler(0, currentX, 0);
    }
}
