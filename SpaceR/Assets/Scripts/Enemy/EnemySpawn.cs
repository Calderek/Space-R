using Assets.Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    public GameObject enemy_Perfabs;
    public Transform place_spawn;

    private EnemyInfo enemyInfo;

	// Use this for initialization
	void Start ()
    {   
        for(int i=0;i<EnemyHelper.enemyAmount;i++)
        {
            var enemy=Instantiate(enemy_Perfabs, place_spawn);
            enemy.name = "Enemy " + (i + 1);
            enemyInfo = enemy_Perfabs.GetComponent<EnemyInfo>();
            enemyInfo.rowPlace = i/4;
            enemyInfo.colPlace = i % 4;
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
