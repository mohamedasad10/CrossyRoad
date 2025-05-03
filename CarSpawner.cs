using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    // Prefab of car to be spawned - assign in the Inspector
    [SerializeField] private GameObject carPrefab;

    // Transform indicating where cars should be spawned
    [SerializeField] private Transform spawnPoint;

    // Time interval (in seconds) between each car spawn
    [SerializeField] private float spawnInterval = 2f;

    private void Start()
    {
        // Repeatedly call SpawnCar starting immediately, then every 'spawnInterval' seconds
        InvokeRepeating(nameof(SpawnCar), 0f, spawnInterval);
    }

    private void SpawnCar()
    {
        // Instantiate a new car at the spawn point's position and rotation
        Instantiate(carPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
