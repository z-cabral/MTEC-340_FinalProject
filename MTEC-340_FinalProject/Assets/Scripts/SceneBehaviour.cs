using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBehaviour : MonoBehaviour
{
    //public static SceneBehaviour Instance;

/*    private void Awake()
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
*/
    //public bool SceneWasLoaded()
    //{
        //return SceneManager.activeSceneChanged;
    //}

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);
        GameStateMachine.Instance.SetState(GameStateMachine.Instance.playState);
    }

    public void ChangeToScene(int index)
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadSceneAsync(index);
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PreviousScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public int GetCurrentScene()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
