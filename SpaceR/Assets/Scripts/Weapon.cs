using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Wstępne ogarnięcie funkcjonalności strzelania. Pew pew! */

public class Weapon : MonoBehaviour {

    public GameObject m_BulletPrefab;
    public Transform m_BulletSpawnPoint;

    //Podstawowe parametry pocisku

    public float m_Velocity = 30; //Prędkość pocisku
    public float m_LifeTime = 0.5f; //Długość życia pocisku
    public float m_FireRate = 0.5f; //Szybkostrzelność

    private bool m_CanShoot = true;


    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKey(KeyCode.Space) && m_CanShoot)
        {
            StartCoroutine(Fire());
        }
    }

    //Tutaj spawn / despawn pocisków, kontrola szybkostrzelności

    public IEnumerator Fire()
    {
        WeaponSwitcher weapon = gameObject.GetComponent<WeaponSwitcher>() as WeaponSwitcher;
        var bullet = (GameObject)Instantiate(weapon.weaponList[weapon.currentWeapon], m_BulletSpawnPoint.position, m_BulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * m_Velocity;

        m_CanShoot = false;
        yield return new WaitForSeconds(m_FireRate);
        m_CanShoot = true;
        Destroy(bullet, m_LifeTime);
    }
}
