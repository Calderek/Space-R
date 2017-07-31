using Assets.Helper;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    public GameObject enemy_Perfabs;
    public Transform place_spawn;
    public string Direction;

    private EnemyInfo enemyInfo;
    private int i = 0;

	// Use this for initialization
	void Start ()
    {

        InvokeRepeating("CreateEnemy", 2.2f, 1.2f);
    }

    private void CreateEnemy()
    {
        var enemy = Instantiate(enemy_Perfabs, place_spawn);
        enemy.name = "Enemy " + i ;
        enemyInfo = enemy.GetComponent<EnemyInfo>();
        enemyInfo.rowPlace = i / 4;
        enemyInfo.colPlace = i % 4;
        enemyInfo.health = EnemyHelper.defaultHealth;
        enemyInfo.direction = Direction;
        i++;

        if (i>=EnemyHelper.amount )
            CancelInvoke("CreateEnemy");
    }


}
