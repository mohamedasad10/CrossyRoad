// This script handles the end-of-level trigger: when the player reaches the trigger zone,
// it shows a "Next Level" UI, plays a completion effect, pauses the game, and allows the player
// to load the next scene by clicking a button.


using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelEndTrigger : MonoBehaviour
{
    public GameObject nextLevelCanvas;     // Assign "Next Level" Canvas
    public Button nextLevelButton;         // Assign the Button inside the Canvas
    public string nextSceneName;           // Name of the next scene
    public ParticleSystem completionEffect; // Assign the particle system to play on completion

    private void Start()
    {
        if (nextLevelButton != null)
        {
            nextLevelButton.onClick.AddListener(LoadNextScene);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (nextLevelCanvas != null)
            {
                nextLevelCanvas.SetActive(true); // Show "Next Level" canvas
                Time.timeScale = 0f;             // Optional: Pause the game
            }

            if (completionEffect != null)
            {
                completionEffect.Play(); // Trigger particle system
            }
        }
    }

    public void LoadNextScene()
    {
        Time.timeScale = 1f; // Resume time before switching scenes
        SceneManager.LoadScene(nextSceneName);
    }
}
