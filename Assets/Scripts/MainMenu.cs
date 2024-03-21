using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string levelSceneName = "level";
    private enum PlayType
    {
        InEditor = 0,
        Built = 1
    }

    [SerializeField] private PlayType playType = PlayType.Built;
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(levelSceneName);
    }

    public void QuitGame()
    {
        // Application.Quit() exits a built application.
        // It does not work while testing inside the Unity editor.
        if (playType == PlayType.InEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }

    }
}
