using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class GuiBehaviour : MonoBehaviour
{
    public static GuiBehaviour Instance;
    bool timerIsRunning = true;
    public float duration = 10f;
    float fadeAmount = 0f;

    public GameObject
        audioDisplaySettings,
        postProcessingSettings,
        gameplaySettings,
        settingsMenu,
        GameOverScreen;

    [SerializeField] AudioMixerSnapshot paused, unpaused;

    AudioDisplayControl audioDisplayControl;

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

        audioDisplayControl = GameObject.Find("StartCam").GetComponent<AudioDisplayControl>();
        
        //        audioDisplayControl.SetUpResolutions()
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        Cursor.lockState = CursorLockMode.Locked;

        ToggleMenu();
    }
    
    public bool FadeOut()
    {
        //IEnumerator coroutine = FadeToBlack();
        //bool finished;
        float fadeSpeed = 1f;
        //StartCoroutine(coroutine);
        Image objectColor = GameOverScreen.GetComponent<Image>();

        objectColor.color = Color.Lerp(objectColor.color, Color.black, fadeSpeed * Time.deltaTime);
        if (objectColor.color.a >= 0.95f)
            return true; // set a flag to indicate fade is finished
        return false;
    }

    public void ResetGameOverScreen()
    {
        Color objectColor = GameOverScreen.GetComponent<Image>().color;

        objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, 0);
        GameOverScreen.GetComponent<Image>().color = objectColor;
    }

    public IEnumerator FadeToBlack(bool fadeToBlack = true, float fadeSpeed = 0.01f)
    {
        Color objectColor = GameOverScreen.GetComponent<Image>().color;
        float fadeAmount = objectColor.a;

        if (fadeToBlack)
        {
            while(GameOverScreen.GetComponent<Image>().color.a < 1)
            {
                fadeAmount += (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                GameOverScreen.GetComponent<Image>().color = objectColor;
            }
        }
        else
        {
            while (GameOverScreen.GetComponent<Image>().color.a > 0)
            {
                fadeAmount -= (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                GameOverScreen.GetComponent<Image>().color = objectColor;
            }
        }
        yield return new WaitForEndOfFrame();
    }

    public void Pause()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        Lowpass(0.1f);

        ToggleMenu();
    }

    public void ToggleMenu()
    {
        if (settingsMenu.activeSelf == false)
        {
            settingsMenu.SetActive(true);
        }
        else if (settingsMenu.activeSelf == true)
        {
            settingsMenu.SetActive(false);
        }

        if (Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void Lowpass(float transitionTime)
    {
        if (Time.timeScale == 0)
            paused.TransitionTo(transitionTime);
        else
            unpaused.TransitionTo(transitionTime);
    }

    public void SettingsPicker(int index)
    {
        switch (index)
        {
            default:
            case 0:
                gameplaySettings.SetActive(false);
                audioDisplaySettings.SetActive(false);
                postProcessingSettings.SetActive(false);
                break;
            case 1:
                gameplaySettings.SetActive(true);
                audioDisplaySettings.SetActive(false);
                postProcessingSettings.SetActive(false);
                break;
            case 2:
                gameplaySettings.SetActive(false);
                audioDisplaySettings.SetActive(true);
                postProcessingSettings.SetActive(false);
                break;
            case 3:
                gameplaySettings.SetActive(false);
                audioDisplaySettings.SetActive(false);
                postProcessingSettings.SetActive(true);
                break;
        }
    }


    public void Quit()
    {
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
