using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class GuiBehaviour : MonoBehaviour
{
    public static GuiBehaviour Instance;

    [SerializeField] GameObject
        audioDisplaySettings,
        postProcessingSettings,
        gameplaySettings,
        settingsMenu;

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

        DontDestroyOnLoad(Instance);

        audioDisplayControl = GameObject.Find("StartCam").GetComponent<AudioDisplayControl>();

        //        audioDisplayControl.SetUpResolutions()
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        Cursor.lockState = CursorLockMode.Locked;

        ToggleMenu();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            Pause();
        }
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
