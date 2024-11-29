using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JoystickAircraftController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float forwardSpeed = 20f; // Forward speed (thrust)
    public float maxSpeed = 50f; // Maximum forward speed
    public float turnSpeed = 45f; // Speed of turning (yaw)
    public float rollSpeed = 45f; // Speed of rolling (banking)
    public float pitchSpeed = 25f; // Speed of pitching (up/down)
    public float smoothTurnTime = 0.2f; // Time for smooth turning
    private float currentSpeed = 0f; // Current forward speed
    private float smoothTurnVelocity; // For smooth turning
    public int CurrentLives = 3; // Player lives
    public Transform LvlSpawnPos; // Spawn position reference
    private Rigidbody rb; // Rigidbody reference
    private EnemyAI eai; // Enemy AI (optional)

    [Header("Joystick Controls")]
    public Joystick movementJoystick; // Reference to the movement joystick
   public Joystick speedJoystick; // Reference to a throttle joystick (optional)

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        eai = GetComponent<EnemyAI>();
        rb.freezeRotation = true; // Disable physics rotation for manual control
    }

    void Update()
    {
        HandleMovement();
        LivesDetect();
    }

    private void HandleMovement()
    {
        // Forward movement based on throttle joystick or a fixed speed
        float throttleInput = speedJoystick != null ? speedJoystick.Vertical : 1f; // Use throttle joystick or constant speed
        currentSpeed = Mathf.Lerp(currentSpeed, maxSpeed * Mathf.Clamp01(throttleInput), Time.deltaTime);

        // Get horizontal and vertical input from movement joystick
        float horizontalInput = movementJoystick.Horizontal; // Horizontal axis (turning)
        float verticalInput = movementJoystick.Vertical; // Vertical axis (pitch)

        // Smooth the turning for yaw
        float smoothTurn = Mathf.SmoothDampAngle(transform.eulerAngles.z, transform.eulerAngles.z + (horizontalInput * turnSpeed), ref smoothTurnVelocity, smoothTurnTime);

        // Smooth pitch control
        float pitch = verticalInput * pitchSpeed;

        // Apply forward velocity (thrust)
        rb.velocity = transform.up * currentSpeed;

        // Keep the Z-position fixed while updating rotation
        Vector3 currentPosition = transform.position;
        currentPosition.z = 0; // Lock the Z-position to 0
        transform.position = currentPosition;

        // Adjust rotation based on yaw (turning), pitch (nose up/down), and roll (bank)
        transform.rotation = Quaternion.Euler(pitch, 0, smoothTurn);

        // Apply rolling (banking) based on the horizontal input (yaw)
        transform.Rotate(0, 0, -horizontalInput * rollSpeed * Time.deltaTime); // Roll to the left/right while turning
    }

    void LivesDetect()
    {
        if (CurrentLives == 0)
        {
            Debug.Log("Game Over");
            string currentScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentScene);
        }
    }

    public void LevelReset()
    {
        this.gameObject.transform.position = LvlSpawnPos.transform.position;
        this.gameObject.SetActive(true);
        CurrentLives--;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the player hits an enemy bullet (collision detection)
        if (collision.collider.CompareTag("Enemy Bullet"))
        {
            this.gameObject.SetActive(false);
            Debug.Log("Game Over!");
            LevelReset();
        }
    }
}