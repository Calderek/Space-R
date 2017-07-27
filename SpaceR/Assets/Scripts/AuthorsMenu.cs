using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuthorsMenu : MonoBehaviour {

    public GameObject StartScreen;
    public GameObject AuthorsScreen;

    public void BackFromAuthors()
    {
        AuthorsScreen.SetActive(false);
        StartScreen.SetActive(true);
        
    }

}
