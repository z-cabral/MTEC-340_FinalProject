using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class GuiBehaviour : MonoBehaviour
{
    [SerializeField] GameObject
        audioDisplaySettings,
        postProcessingSettings,
        settingsMenu;

    [SerializeField] AudioMixerSnapshot paused, unpaused;

    private void Update()
    {
        

        if (Input.GetButtonDown("Pause"))
        {
            if(settingsMenu.activeSelf == false)
            {
                settingsMenu.SetActive(true);
            }
            else if (settingsMenu.activeSelf == true)
            {
                settingsMenu.SetActive(false);
            }

            Pause();

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
    }

    void Pause()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        Lowpass(0.1f);

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
                //audioSettings.SetActive(false);
                audioDisplaySettings.SetActive(false);
                postProcessingSettings.SetActive(false);
                break;
            case 0:
                //audioSettings.SetActive(true);
                audioDisplaySettings.SetActive(true);
                postProcessingSettings.SetActive(false);
                break;
            case 1:
                //audioSettings.SetActive(false);
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
