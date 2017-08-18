using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseScreen;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            pauseScreen.SetActive(true);
        }

    }
        



	public void RestartGame()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        SceneManager.LoadScene(0);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }
}
