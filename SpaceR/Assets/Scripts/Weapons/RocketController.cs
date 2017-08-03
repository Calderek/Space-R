using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour {

    public ParticleSystem expPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision coll)
    {
        Instantiate(expPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
