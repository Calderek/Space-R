using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour {

    public GameObject GraphicsScreen;
    public GameObject ControlScreen;
    public GameObject AudioScreen;
    public GameObject SettingsScreen;
    public GameObject StartScreen;

    public void GraphicsMenu()
    {
        
        SettingsScreen.SetActive(false);
        GraphicsScreen.SetActive(true);
    }
    public void ControlMenu()
    {

        SettingsScreen.SetActive(false);
        ControlScreen.SetActive(true);
    }
    public void AudioMenu()
    {

        SettingsScreen.SetActive(false);
        AudioScreen.SetActive(true);
    }
    public void BackFromSettings()
    {

        SettingsScreen.SetActive(false);
        StartScreen.SetActive(true);
    }

}
