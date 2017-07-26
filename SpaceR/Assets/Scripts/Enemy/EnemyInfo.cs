using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour {

    public int rowPlace;
    public int colPlace;

    private Vector3 position;
    private Vector3 finishPosition;

    //private Vector3 Startposition;

    private bool leftMove=false;
    private bool downMove = false;


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

        position = transform.position;
        downMove = position.z <= finishPosition.z ? false : true;
        Debug.Log(position.z + "   " + finishPosition.z);
        leftMove = position.x <= finishPosition.x ? false : true;

        float movement = Time.deltaTime * 5;

        if(downMove)
        {
            transform.Translate(-movement, 0, 0);
        }
        else
        {
            //leftMove = position.z >= finishPosition.z ? false : true;
            //Debug.Log(leftMove);
            if (leftMove)
            {
                transform.Translate(0, movement, 0);

            }
        }


        //Debug.Log(Time.deltaTime);


    }
}
