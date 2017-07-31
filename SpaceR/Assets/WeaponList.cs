using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponList : MonoBehaviour {

   // private WeaponController weapon;
    public List<WeaponConstructor> weaponList = new List<WeaponConstructor>();

    [Header("Laser attributes")]
    public GameObject laserPrefab;
    public int l_damage=1;
    public float l_rof=0.2f;
    public float l_velocity=50;
    public float l_lifetime=2.5f;
    [Header("Rocket attributes")]
    public GameObject rocketPrefab;
    public int r_damage=5;
    public float r_rof=1.0f;
    public float r_velocity=50;
    public float r_lifetime=2.5f;


    // Use this for initialization
    void Start () {
       // weapon = gameObject.GetComponent<WeaponController>() as WeaponController;

        weaponList.Insert(0,  new WeaponConstructor(laserPrefab, l_damage, l_rof, l_velocity, l_lifetime));
        weaponList.Insert(1,  new WeaponConstructor(rocketPrefab, r_damage, r_rof, r_velocity, r_lifetime));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
