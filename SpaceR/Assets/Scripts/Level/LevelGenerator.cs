using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var enemies = GameObject.FindGameObjectsWithTag("enemy");
        

        if(enemies.Length==0 )
        {
            Debug.Log("Level zakończony");
        }
        

    }
}
