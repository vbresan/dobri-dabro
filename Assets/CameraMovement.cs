using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private Transform playerBody;

    private float yRotation = 0f;

    // called before the first frame, i.e. before Start
    //  used for initialization of components
    private void Awake()
    {
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    //  FPS will depend on the hardware and the complexity of the game
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        playerBody.Rotate(Vector3.up * mouseX);

        yRotation -= mouseY;
        yRotation = Mathf.Clamp(yRotation, -80f, 80f);
        transform.localRotation = Quaternion.Euler(yRotation, 0f, 0f);



        if (Input.GetAxis("Jump") > 0)
        {
            Debug.Log("Jump");
        }

    }

    // Project Settings -> Time -> Fixed Timestep
    //  Used for example for physics calculations that should not depend on
    //  the frame rate which is variable
    private void FixedUpdate() 
    {

    }

    // Similar like Update, but is called after Update
    //  Rarely used
    private void LateUpdate()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    private void OnApplicationQuit()
    {
        
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }
}
