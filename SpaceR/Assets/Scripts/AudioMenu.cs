using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMenu : MonoBehaviour {
    public GameObject AudioScreen;
    public GameObject SettingsScreen;

    public void BackFromAudio()
    {
        AudioScreen.SetActive(false);
        SettingsScreen.SetActive(true);
    }

}
