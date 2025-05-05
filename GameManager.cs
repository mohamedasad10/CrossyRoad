// This script is attached to the GameObject called GameManager. 
// It keeps track of how long the player has survived and dynamically increases 
// the car's speed over time to make the game more challenging. 
// Other scripts (like CarMovement) can access the current car speed through this script.


using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private float elapsedTime = 0f;

    [SerializeField] private float baseCarSpeed = 5f;
    [SerializeField] private float speedIncreasePerSecond = 0.1f;
    [SerializeField] private float maxCarSpeed = 20f;

    private void Awake()
    {
        // Singleton pattern so any script can access GameManager.Instance
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
    }

    public float GetCurrentCarSpeed()
    {
        return Mathf.Min(baseCarSpeed + (elapsedTime * speedIncreasePerSecond), maxCarSpeed);
    }
}
