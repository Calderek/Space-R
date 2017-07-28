using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour {
    
    public Transform Player;
    public GameObject ScreenStart;
    public GameObject ScreenSettings;
    public GameObject ScreenAuthors;

    void Start()
    {
        Time.timeScale = 0;
    }

    public void GameActivation()
    {
        Player.GetComponent<PlayerMovement>().enabled = true;
        ScreenStart.SetActive(false);
        Time.timeScale = 1;
    }
    public void StartMenuSettings()
    {
        ScreenStart.SetActive(false);
        ScreenSettings.SetActive(true);
    }
    public void AuthorsList()
    {
        ScreenStart.SetActive(false);
        ScreenAuthors.SetActive(true);
    }
    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }


}
