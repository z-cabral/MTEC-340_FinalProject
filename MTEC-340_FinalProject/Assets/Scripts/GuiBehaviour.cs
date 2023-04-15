using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiBehaviour : MonoBehaviour
{
    [SerializeField] GameObject
        audioSettings,
        displaySettings,
        postProcessingSettings,
        settingsMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(settingsMenu.activeSelf == false)
            {
                settingsMenu.SetActive(true);
                Time.timeScale = 0f;
            }
            else if (settingsMenu.activeSelf == true)
            {
                settingsMenu.SetActive(false);
                Time.timeScale = 1f;
            }
        }
    }

    public void SettingsPicker(int index)
    {
        switch (index)
        {
            default:
                audioSettings.SetActive(false);
                displaySettings.SetActive(false);
                postProcessingSettings.SetActive(false);
                break;
            case 0:
                audioSettings.SetActive(true);
                displaySettings.SetActive(false);
                postProcessingSettings.SetActive(false);
                break;
            case 1:
                audioSettings.SetActive(false);
                displaySettings.SetActive(true);
                postProcessingSettings.SetActive(false);
                break;
            case 2:
                audioSettings.SetActive(false);
                displaySettings.SetActive(false);
                postProcessingSettings.SetActive(true);
                break;
        }
    }
}
