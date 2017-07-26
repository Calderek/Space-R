using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    public GameObject enemy_Perfabs;
    public Transform place_spawn;

	// Use this for initialization
	void Start ()
    {   
        for(int i=0;i<16;i++)
        {
            var enemy=Instantiate(enemy_Perfabs, place_spawn);
            enemy.name = "Enemy " + (i + 1);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
