using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphicsMenu : MonoBehaviour {

    public Toggle fullScreenToggle;
    public Dropdown resolutionDropdown;
    public Dropdown textureQualityDropdown;

    public Resolution[] resolutions;
    public GraphicsSettings graphicsSettings;

    void OnEnable()
    {
        graphicsSettings = new GraphicsSettings();

        fullScreenToggle.onValueChanged.AddListener(delegate { OnFullScreenToggle(); });
        resolutionDropdown.onValueChanged.AddListener(delegate { OnResolutionChange(); });
        textureQualityDropdown.onValueChanged.AddListener(delegate { OnTextureQualityChange(); });


        resolutions = Screen.resolutions;
    }

    public void OnFullScreenToggle()
    {
        graphicsSettings.fullScreen = Screen.fullScreen = fullScreenToggle.isOn;
        QualitySettings.masterTextureLimit = graphicsSettings.textureQuality = textureQualityDropdown.value; 
    }

    public void OnResolutionChange()
    {

    }

    public void OnTextureQualityChange()
    {

    }
    public void SaveSettings()
    {

    }

}
