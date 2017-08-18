using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestruction : MonoBehaviour {

    public ParticleSystem expPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        var hit = collision.collider.tag;

        Instantiate(expPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
