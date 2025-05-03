using System.Collections; // For using coroutines (time-based actions)
using UnityEngine; // Unity-specific features
using UnityEngine.InputSystem; // For handling player input

public class PlayerMovement : MonoBehaviour
{
    // InputActions to handle user movement inputs (forward, left, right)
    [SerializeField] InputAction moveForward;
    [SerializeField] InputAction moveLeft;
    [SerializeField] InputAction moveRight;

    // Settings for jump behavior (height and duration of the jump arc)
    [SerializeField] float jumpHeight = 2f;
    [SerializeField] float jumpDuration = 0.3f;

    // Particle system to play when the object jumps
    [SerializeField] ParticleSystem ps;

    [SerializeField] private GameObject gameOverText;

    //Restart Button
    [SerializeField] private GameObject restartButton;

    // Keeps track of whether the object is currently jumping
    private bool isJumping = false;

    // Reference to the Rigidbody component for physics calculations
    private Rigidbody rb;

    private void Start()
    {
        // Get the Rigidbody component attached to this GameObject
        rb = GetComponent<Rigidbody>();

        // Set the Rigidbody to be kinematic to manually control movement instead of using physics forces
        rb.isKinematic = true;
    }

    private void OnEnable()
    {
        // Enable the input actions so the game can detect user input
        moveForward.Enable();
        moveLeft.Enable();
        moveRight.Enable();
    }

    private void OnDisable()
    {
        // Disable the input actions when the object is disabled to prevent memory leaks
        moveForward.Disable();
        moveLeft.Disable();
        moveRight.Disable();
    }

    private void Update()
    {
        // If the object is already jumping, prevent new input (no double jumping)
        if (isJumping) return;

        // Check if the player pressed the moveForward input
        if (moveForward.triggered)
        {
            // Start a coroutine to make the object jump forward
            StartCoroutine(SmoothJump(Vector3.forward, Quaternion.LookRotation(Vector3.forward)));
        }
        // Check if the player pressed the moveLeft input
        else if (moveLeft.triggered)
        {
            // Start a coroutine to make the object jump left
            StartCoroutine(SmoothJump(Vector3.left, Quaternion.LookRotation(Vector3.left)));
        }
        // Check if the player pressed the moveRight input
        else if (moveRight.triggered)
        {
            // Start a coroutine to make the object jump right
            StartCoroutine(SmoothJump(Vector3.right, Quaternion.LookRotation(Vector3.right)));
        }
    }

    // Coroutine to handle the smooth jump animation
    private IEnumerator SmoothJump(Vector3 direction, Quaternion targetRotation)
    {
        // Set the jumping flag to true to prevent other jumps during this one
        isJumping = true;

        // Record the starting position and calculate the target position
        Vector3 startPos = transform.position;
        Vector3 endPos = startPos + direction;

        // Track the time elapsed during the jump
        float elapsed = 0f;

        // If the particle system is assigned, start playing it (jump particle effect)
        if (ps != null)
        {
            ps.Play();
        }

        // Loop over time to create a smooth jump arc
        while (elapsed < jumpDuration)
        {
            // t is a value between 0 and 1 that represents the progress of the jump
            float t = elapsed / jumpDuration;

            // Calculate the height of the jump arc based on the formula
            float height = 4 * jumpHeight * t * (1 - t); // Parabolic arc

            // Move the object along the path and apply the height for jumping
            transform.position = Vector3.Lerp(startPos, endPos, t) + Vector3.up * height;

            // Smoothly rotate the object to face the target direction (forward, left, or right)
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, t);

            // Increment the elapsed time and wait until the next frame
            elapsed += Time.deltaTime;
            yield return null;
        }

        // After the jump is finished, snap to the exact end position and rotation
        transform.position = endPos;
        transform.rotation = targetRotation;

        // Reset the jumping flag
        isJumping = false;
    }

    //COLLISIONS
    // Called when the player enters a trigger collider
    private void OnTriggerEnter(Collider other)
    {
    // Check if the collided object has the "Car" tag
        if (other.CompareTag("Car"))
        {
            // Pause the game by setting time scale to 0 effectively ending the game
            Time.timeScale = 0f;
            // Log a message for debugging
            Debug.Log("Game Over: Player collided with a car!");

            if (gameOverText != null)
            {
                gameOverText.SetActive(true); // Show Game Over message
            }
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Unpause the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload current scene
    }
}
