using Assets.Helper;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var enemies = GameObject.FindGameObjectsWithTag("enemy");


        if (enemies.Length == 0 && GameHelper.LevelStarted)
        {
            ///todo  if level finish
            GameHelper.CurrentLevel++;
            GameHelper.LevelStarted = false;
            GameHelper.StartNewLevel = true;

        }
        

    }
}
