using Assets.Helper;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    public GameObject enemy_Perfabs;
    public Transform place_spawn;
    public string Direction;

    private EnemyInfo enemyInfo;
    private int i = 1;

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
        enemyInfo.health = EnemyHelper.defaultHealth;
        enemyInfo.direction = Direction;
        i++;
    }
	
}
