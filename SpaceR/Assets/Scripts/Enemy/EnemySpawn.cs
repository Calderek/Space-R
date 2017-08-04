using Assets.Helper;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    public GameObject enemy_Perfabs;
    public Transform place_spawn;
    public string Direction;

    private EnemyInfo enemyInfo;
    private int i = 0;

    private bool invoke;

	// Use this for initialization
	void Start ()
    {
        invoke = true;
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
        enemy.tag = "enemy";
        GameHelper.LevelStarted = true;

        if (i>=EnemyHelper.amount )
        {
            CancelInvoke("CreateEnemy");
            invoke = false;
        }
    }


    void Update()
    {
        if(GameHelper.StartNewLevel && !invoke)
        {
            InvokeRepeating("CreateEnemy", 2.2f, 1.2f);
            GameHelper.CountSpawnerInLevel++;
            if(GameHelper.CountSpawnerInLevel==2)
            {
                GameHelper.CountSpawnerInLevel = 0;
                GameHelper.StartNewLevel = false;
            }

        }
    }


}
