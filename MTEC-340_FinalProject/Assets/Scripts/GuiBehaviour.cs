using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiBehaviour : MonoBehaviour
{
    [SerializeField] GameObject
        audioDisplaySettings,
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
}
