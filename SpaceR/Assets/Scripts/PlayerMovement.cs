//Skrypt ma za zadanie poruszanie statkiem gracza za pomoca stralek gora i dol oraz przyciskow w, s, a i d


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float movSpeed = 5f; // zmienna sterujacy czuloscia poruszania statkiem
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal") * Time.deltaTime * movSpeed;
            //przechowuje zawartość klikniecia zalezna od danej stralki(-1 do 1)
        float v = Input.GetAxis("Vertical") * Time.deltaTime * movSpeed;
        //to samo tylko strzalki gora, dol

        transform.Translate(-v, h, 0);   //zmiana polozenia obiektu w oparciu o zawartosc zmiennych

    }
}
