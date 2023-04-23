using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBehaviour : MonoBehaviour
{
    public static SceneBehaviour Instance;

    public int currentScene;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(Instance);
    }

    public void NewGame()
    {
        GuiBehaviour.Instance.ToggleMenu();
        SceneManager.UnloadSceneAsync(0);
        SceneManager.LoadScene(1);
    }

    public void ChangeToScene(int index)
    {
        SceneManager.UnloadSceneAsync(currentScene);
        SceneManager.LoadScene(index);
    }

    public void NextScene()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.UnloadSceneAsync(currentScene);
        SceneManager.LoadScene(currentScene + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
