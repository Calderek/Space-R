using Assets.Helper;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {


    private Vector3 position;
    private Vector3 finishPosition;

    private bool leftMove = false;
    private bool downMove = false;
    private int rowPlace;
    private int colPlace;

    // Use this for initialization
    void Start()
    {

        var spaceInformation = GetComponent<EnemyInfo>();
        rowPlace = spaceInformation.rowPlace;
        colPlace = spaceInformation.colPlace;
        position = transform.position;

        //todo helper for placement spawn enemy
        finishPosition = new Vector3();
        finishPosition.x = rowPlace * 8 - 8;
        finishPosition.z = colPlace * 8 - 8;
        finishPosition.y = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float movement = Time.deltaTime * EnemyHelper.defaultVelocity;
        position = transform.position;
        downMove = position.z <= finishPosition.z ? false : true;

        switch(GetComponent<EnemyInfo>().direction)
        {
            case "left":
                {
                    leftMove = position.x >= finishPosition.x ? false : true;

                    if (downMove)
                    {
                        transform.Translate(-movement, 0, 0);
                    }
                    else
                    {

                        if (leftMove)
                        {
                            transform.Translate(0, -movement, 0);

                        }
                    }


                    break;
                }
            case "right":
                {
                    leftMove = position.x <= finishPosition.x ? false : true;
                    if (downMove)
                    {
                        transform.Translate(-movement, 0, 0);
                    }
                    else
                    {
                        if (leftMove)
                        {
                            transform.Translate(0, movement, 0);

                        }
                    }
                    break;
                }
        }
    }
}
