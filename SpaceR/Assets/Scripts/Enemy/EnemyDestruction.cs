using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestruction : MonoBehaviour {

    public int health = 3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision coll)
    {
        Bullet bullet = coll.collider.GetComponent<Bullet>() as Bullet;

        if(bullet != null)
        {
            health--;
        }
        if(health <=0)
        {
            Destroy(gameObject);
        }
    }
}
