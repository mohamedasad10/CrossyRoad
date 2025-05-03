using UnityEngine;

public class CarMovement : MonoBehaviour
{
    // Car Speed
    [SerializeField] private float speed = 5f;

    // Max distance car can travel before being destroyed
    [SerializeField] private float maxTravelDistance = 50f;

    // The position where the car was initially spawned
    private Vector3 startPos;

    private void Start()
    {
        // Store the spawn position for distance tracking
        startPos = transform.position;
    }

    private void Update()
    {
        // Continuously move the car in its forward direction
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Check if the car has moved beyond the allowed distance
        if (Vector3.Distance(startPos, transform.position) >= maxTravelDistance)
        {
            // Destroy the car to prevent memory overload
            Destroy(gameObject);
        }
    }
}
