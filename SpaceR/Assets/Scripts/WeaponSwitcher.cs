using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour {

    public List<GameObject> weaponList;
    public int currentWeapon = 0;
    

    // Use this for initialization
    void Start()
    {
        SwitchWeapon(currentWeapon);
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 1; i <= weaponList.Count; i++)
        { 
            if (Input.GetKeyDown("" + i))
            {
                currentWeapon = i - 1;
                SwitchWeapon(currentWeapon);
            }
        }
    }

    void SwitchWeapon(int index)
    {
        for (int i = 0; i < weaponList.Count; i++)
        {
            if (i == index)
            {
                weaponList[i].gameObject.SetActive(true);
            }
            else
            {
                weaponList[i].gameObject.SetActive(false);
            }
        }
    }
}
