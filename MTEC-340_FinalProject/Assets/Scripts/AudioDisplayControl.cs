using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class AudioDisplayControl : MonoBehaviour
{
    Resolution[] resolutions;

    public TMPro.TMP_Dropdown resolutionDropdown;

    public AudioMixer mainMix;

    private void Awake()
    {
        //resolutionDropdown = GuiBehaviour.Instance.GetComponentInChildren<TMP_Dropdown>();
        resolutions = Screen.resolutions;
    }

    public void Start()
    {
        SetUpResolutions(resolutions);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetUpResolutions(Resolution[] resolutions)
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int ResolutionIndex)
    {
        Resolution resolution = resolutions[ResolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void AdjustMasterLevel(float level)
    {
        float logLevel = 20.0f * Mathf.Log10(level);
        mainMix.SetFloat("MasterLevel", logLevel);
    }

    public void AdjustMusicLevel(float level)
    {
        float logLevel = 20.0f * Mathf.Log10(level);
        mainMix.SetFloat("MusicLevel", logLevel);
    }

    public void AdjustSFXLevel(float level)
    {
        float logLevel = 20.0f * Mathf.Log10(level);
        mainMix.SetFloat("SFXLevel", logLevel);
    }

    public void AdjustDialogueLevel(float level)
    {
        float logLevel = 20.0f * Mathf.Log10(level);
        mainMix.SetFloat("DialogueLevel", logLevel);
    }
}
