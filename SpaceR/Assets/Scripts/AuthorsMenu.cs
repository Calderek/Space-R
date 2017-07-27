using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuthorsMenu : MonoBehaviour {

    public GameObject SettingsScreen;
    public GameObject AuthorsScreen;

    public void BackFromAuthors()
    {
        AuthorsScreen.SetActive(false);
        SettingsScreen.SetActive(true);
        
    }

}
