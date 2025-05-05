using UnityEngine;

public class CarMovement : MonoBehaviour
{
    // Maximum distance the car can travel before being destroyed
    [SerializeField] private float maxTravelDistance = 50f;

    // The starting position of the car
    private Vector3 startPos;

    // Store the initial position when the car is spawned
    private void Start()
    {
        startPos = transform.position;
    }

    // Move the car forward and destroy it if it exceeds the allowed distance
    private void Update()
    {
        // Get the current speed from the GameManager
        float speed = GameManager.Instance.GetCurrentCarSpeed();

        // Move the car forward based on speed and time
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Check if the car has traveled beyond the max distance
        if (Vector3.Distance(startPos, transform.position) >= maxTravelDistance)
        {
            // Destroy the car object to free resources
            Destroy(gameObject);
        }
    }
}
