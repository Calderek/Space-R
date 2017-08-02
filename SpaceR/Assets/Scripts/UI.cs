using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    WeaponList weapon;

    public Text HUDText;

    // Use this for initialization
    void Start()
    {
        weapon = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponList>();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(weapon.ammo);
        //HUDText.text = "Ammo: " + weapon.ammo.ToString() + "\n" + "HP: " + weapon.hp.ToString();
    }
}
