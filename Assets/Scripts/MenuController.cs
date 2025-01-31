using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartButton()
    {
        // Load the GameScene when the Start button is pressed
        SceneManager.LoadScene("GameScene");
    }

    public void BackToMenu()
    {
        // Return to the Main Menu from the GameScene
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        // The game can be exited in the Unity Editor or from the built application on the Quest

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
