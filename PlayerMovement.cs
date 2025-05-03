using System.Collections; // For using coroutines (time-based actions)
using UnityEngine; // Unity-specific features
using UnityEngine.InputSystem; // For handling player input

public class PlayerMovement : MonoBehaviour
{
    // InputActions to handle user movement input
    [SerializeField] InputAction moveForward; 

    // Jump settings: height and duration
    [SerializeField] float jumpHeight = 2f;
    [SerializeField] float jumpDuration = 0.3f;

    // Particle system for jump effect
    [SerializeField] ParticleSystem ps;

    // Keeps track of the jumping state
    private bool isJumping = false;

    // Rigidbody for physics-based calculations
    private Rigidbody rb;

    private void Start()
    {
        // Get the Rigidbody component attached to this GameObject
        rb = GetComponent<Rigidbody>();

        // Set Rigidbody to kinematic to allow manual control
        rb.isKinematic = true;
    }

    private void OnEnable()
    {
        // Enable input actions to detect user input
        moveForward.Enable();
    }

    private void OnDisable()
    {
        // Disable input actions to prevent memory leaks
        moveForward.Disable();
    }

    private void Update()
    {
        // If already jumping, don't process any new input
        if (isJumping) return;

        // Check for forward movement
        if (moveForward.triggered)
        {
            StartCoroutine(SmoothJump(Vector3.forward, Quaternion.LookRotation(Vector3.forward)));
        }
        // Check for left movement
        else if (moveLeft.triggered)
        {
            StartCoroutine(SmoothJump(Vector3.left, Quaternion.LookRotation(Vector3.left)));
        }
        // Check for right movement
        else if (moveRight.triggered)
        {
            StartCoroutine(SmoothJump(Vector3.right, Quaternion.LookRotation(Vector3.right)));
        }
    }


    // Coroutine for smooth jump animation
    private IEnumerator SmoothJump(Vector3 direction, Quaternion targetRotation)
    {
        // Prevent multiple jumps at the same time
        isJumping = true;

        // Record the starting position
        Vector3 startPos = transform.position;
        Vector3 endPos = startPos + direction;

        // Track time elapsed during the jump
        float elapsed = 0f;

        // Start the jump particle effect if it's assigned
        if (ps != null)
        {
            ps.Play();
        }

        // Smooth jump arc over time
        while (elapsed < jumpDuration)
        {
            float t = elapsed / jumpDuration; // Progress of the jump (0 to 1)

            // Calculate the height of the jump
            float height = 4 * jumpHeight * t * (1 - t); // Parabolic arc formula

            // Update the position with a smooth curve and apply the height
            transform.position = Vector3.Lerp(startPos, endPos, t) + Vector3.up * height;

            // Rotate object smoothly towards the target direction
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, t);

            // Increment time and wait for the next frame
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Snap to the final position and rotation after the jump
        transform.position = endPos;
        transform.rotation = targetRotation;

        // Reset the jumping state
        isJumping = false;
    }
}
