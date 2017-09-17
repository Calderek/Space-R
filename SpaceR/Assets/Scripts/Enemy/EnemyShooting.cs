using UnityEngine;
using System.Linq;

public class EnemyShooting : MonoBehaviour
{

    public Vector3 bulletOffset = new Vector3(0, 0, 0.5f);
    System.Random random;
    public float fireDelay;

    private WeaponList list;
    private GameObject oWeapon;
    private float oVelocity;
    private float oLifeTime;

    private float cooldownTimer = 0;

    // Use this for initialization
    void Start()
    {
        var armory = GameObject.FindWithTag("Armory");
        list = armory.GetComponent<WeaponList>();

        random = new System.Random();
        fireDelay = random.Next(1, 20);
        cooldownTimer = random.Next(1, 30);
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer <= 0)
        {
            cooldownTimer = fireDelay;

            Vector3 offset = transform.rotation * bulletOffset;

            oVelocity = list.weaponList.Select(x => list.weaponList[0].Velocity).First();
            oLifeTime = list.weaponList.Select(x => list.weaponList[0].LifeTime).First();
            oWeapon = list.weaponList.Select(x => list.weaponList[0].Weapon).First();

            var bullet = Instantiate(oWeapon, transform.position + offset, transform.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * oVelocity * (-1);
            bullet.layer = LayerMask.NameToLayer("Enemy Bullet");

            fireDelay = random.Next(1, 30);

            Destroy(bullet, oLifeTime);
        }


    }
}
