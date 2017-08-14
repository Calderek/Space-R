using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WeaponController : MonoBehaviour {

    public Transform bulletSpawnPoint;
    private WeaponList list;

    public int currentWeaponIndex = 0;

    private bool CanShoot = true;

    private GameObject oWeapon;
    private int oDamage;
    private int oAmmo;
    private float oVelocity;
    private float oRof;
    private float oLifeTime;

    //###########################################################################################################

    // Use this for initialization
    void Start ()
    {
        list = GetComponent<WeaponList>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        for (int i = 1; i <= list.weaponList.Count; i++)
        {
            if (Input.GetKeyDown("" + i))
            {
                currentWeaponIndex = i - 1;
            }
        }

        if(Input.GetButton("Fire1") && CanShoot)
        {
            StartCoroutine(Fire());
        }
    }

    //#############################################################################################################

    private void OnTriggerEnter(Collider other)
    {
        
    }

    public IEnumerator Fire()
    {
        oVelocity = list.weaponList.Select(x => list.weaponList[currentWeaponIndex].Velocity).First();
        oRof = list.weaponList.Select(x => list.weaponList[currentWeaponIndex].RoF).First();
        oLifeTime = list.weaponList.Select(x => list.weaponList[currentWeaponIndex].LifeTime).First();
        oWeapon = list.weaponList.Select(x => list.weaponList[currentWeaponIndex].Weapon).First();
        //oAmmo = list.weaponList.Select(x => list.weaponList[currentWeaponIndex].Ammo).First();

        var bullet = Instantiate(oWeapon, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * oVelocity;
        bullet.layer = LayerMask.NameToLayer("Player Bullet");

        CanShoot = false;
        yield return new WaitForSeconds(oRof);
        CanShoot = true;
        Destroy(bullet, oLifeTime);
    }
}
