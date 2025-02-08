using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    
    [SerializeField] private Transform playerCamera;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float movementSpeed = 13;
    [SerializeField] private float jumpHeight = 5;
    [SerializeField] private float gravity = -9.81f;
    
    private bool isGrounded = false;
    private Vector3 velocity;

    private void Crouch() {
        
        bool  isCrouching   = Input.GetKey(KeyCode.C);
        float targetHeight  = isCrouching ? 1f : 2f;
        float targetCameraY = isCrouching ? 0.85f : 1.7f;
        float targetCenterY = isCrouching ? 0.5f : 1f;

        characterController.height = Mathf.Lerp(
            characterController.height,
            targetHeight,
            2 * Time.deltaTime
        );
        characterController.center = new Vector3(
            0,
            Mathf.Lerp(
                characterController.center.y, 
                targetCenterY, 
                2 * Time.deltaTime
            ),
            0
        );
        playerCamera.localPosition = new Vector3(
            0, 
            Mathf.Lerp(
                playerCamera.localPosition.y, 
                targetCameraY, 
                2 * Time.deltaTime
            ),
            0
        );
    }

    void Start() {
        characterController = GetComponent<CharacterController>();
    }

    void Update() {
        float mouseX = Input.GetAxis("Horizontal");
        float mouseZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * mouseX + transform.forward * mouseZ;
        characterController.Move(move * movementSpeed * Time.deltaTime);

        isGrounded = Physics.CheckSphere(groundCheck.position, 0.5f, layerMask);
        if (isGrounded && velocity.y < 0) {
            velocity.y = gravity;
        } else {
            velocity.y += gravity * Time.deltaTime;
        }        
        
        if (Input.GetButtonDown("Jump") && isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -gravity);
        }

        Crouch();

        characterController.Move(velocity * Time.deltaTime);

        if (transform.position.y < -10) {    
            ResetLevel();
        }

        if (Input.GetKeyDown(KeyCode.S)) {
            GetComponent<PlayerHealth>().Save();
            GetComponent<PlayerCoins>().Save();
        }
        if (Input.GetKeyDown(KeyCode.L)) {
            GetComponent<PlayerHealth>().Load();
            GetComponent<PlayerCoins>().Load();
        }
        if (Input.GetKeyDown(KeyCode.R)) {
            ResetLevel();
        }
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }

    private void ResetLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
