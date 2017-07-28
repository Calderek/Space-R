using Assets.Helper;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    public GameObject enemy_Perfabs;
    public Transform place_spawn;

    private EnemyInfo enemyInfo;

    private static int i = 1;
	// Use this for initialization
	void Start ()
    {
        i = 0;
        InvokeRepeating("CreateEnemy", 2.2f, 1.2f);
    }

    private void CreateEnemy()
    {
        if(i==16)
            CancelInvoke("CreateEnemy");
        var enemy = Instantiate(enemy_Perfabs, place_spawn);
        enemy.name = "Enemy " + (i + 1);
        enemyInfo = enemy_Perfabs.GetComponent<EnemyInfo>();
        enemyInfo.rowPlace = i / 4;
        enemyInfo.colPlace = i % 4;
        i++;
    }
	
	// Update is called once per frame
	void Update () {
    }

   
}
