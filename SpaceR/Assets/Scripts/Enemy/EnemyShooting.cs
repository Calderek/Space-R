using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{

    public Vector3 bulletOffset = new Vector3(0, 0, 0.5f);

    public GameObject bulletPrefab;

    System.Random random;

    public float fireDelay;
    float cooldownTimer = 0;

    // Use this for initialization
    void Start()
    {
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

            GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bullet.layer = LayerMask.NameToLayer("Enemy Bullet");

            fireDelay = random.Next(1, 30);
        }
    }
}
