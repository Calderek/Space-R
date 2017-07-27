using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour {
    
    public Transform Player;
    public GameObject ScreenStart;
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
}
