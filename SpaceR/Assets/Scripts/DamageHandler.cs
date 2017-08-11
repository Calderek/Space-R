using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour {

    public int health = 1;
    public ParticleSystem explosionPrefab;

    private void OnTriggerEnter()
    {
        health--;
    }

    private void Update()
    {
        if (health <= 0)
            Explode();
    }


    void Explode()
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
