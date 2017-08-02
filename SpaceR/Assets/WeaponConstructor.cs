using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponConstructor : MonoBehaviour {

    public GameObject Weapon { get; set; }
    public int Damage { get; set; }
    public int Ammo { get; set; }
    public float RoF { get; set; }
    public float Velocity { get; set; }
    public float LifeTime { get; set; }

    public WeaponConstructor(GameObject weapon, int damage, int ammo, float rof, float velocity, float lifetime)
    {
        this.Weapon = weapon;
        this.Damage = damage;
        this.Ammo = ammo;
        this.RoF = rof;
        this.Velocity = velocity;
        this.LifeTime = lifetime;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
