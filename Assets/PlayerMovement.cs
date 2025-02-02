using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float movementSpeed = 13;
    [SerializeField] private float jumpHeight = 5;
    [SerializeField] private float gravity = -9.81f;
    
    private bool isGrounded = false;
    private Vector3 velocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
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
