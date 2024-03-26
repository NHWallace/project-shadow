using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string levelSceneName = "level";
    public BGMController music;

    private void Start()
    {
        // Only one BGMController object should exist
        music = FindObjectOfType(typeof(BGMController)) as BGMController;
    }

    private enum PlayType
    {
        InEditor = 0,
        Built = 1
    }

    [SerializeField] private PlayType playType = PlayType.Built;
    public void PlayGame()
    {
        music.PlayGameBGM();
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
