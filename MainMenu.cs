// The below script is attached to the Start Button in the MainMenu Scene
// This script executes when the user clicks the "start" button in the start menu to play the game

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level1"); // scene name
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game"); // For editor testing
    }
}
