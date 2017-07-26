using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour {

    public int rowPlace;
    public int colPlace;

    private Vector3 position;
    private Vector3 finishPosition;

    //private Vector3 Startposition;


    // Use this for initialization
    void Start () {
        position = transform.position;

        //todo helper for placement spawn enemy
        finishPosition = new Vector3();
        finishPosition.x = rowPlace * 8 - 8;
        finishPosition.z = colPlace * 8 - 8;
        finishPosition.y = 0;
    }
	
	// Update is called once per frame
	void Update () {
        //transform.TransformPoint(Vector3.zero);
        position.x = rowPlace * 8 - 8;
        position.z = colPlace * 8 - 8;
        position.y = 0;
        transform.position = position;
        //transform.localPosition = new Vector3(position.x,position.y,position.z);
        //transform.position = new Vector3(rowPlace * -8 - 8 , transform.position.y, colPlace * -8 - 8 );

    }
}
