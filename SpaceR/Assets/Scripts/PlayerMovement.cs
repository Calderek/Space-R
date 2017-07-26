//Skrypt ma za zadanie poruszanie statkiem gracza za pomoca stralek gora i dol oraz przyciskow w, s, a i d


using Assets.Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        //przechowuje zawartość klikniecia zalezna od danej stralki(-1 do 1)
        float h = Input.GetAxis("Horizontal") * Time.deltaTime * PlayerHelper.movSpeed;
        //to samo tylko strzalki gora, dol
        float v = Input.GetAxis("Vertical") * Time.deltaTime * PlayerHelper.movSpeed;

        //zmiana polozenia obiektu w oparciu o zawartosc zmiennych
        transform.Translate(-v, h, 0);   

    }
}
