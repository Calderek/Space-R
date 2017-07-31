using Assets.Helper;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {


    private Vector3 position;
    private Vector3 finishPosition;

    private bool leftMove = false;
    private bool downMove = false;
    private int rowPlace ;
    private int colPlace;

    // Use this for initialization
    void Start()
    {

        var spaceInformation = GetComponent<EnemyInfo>();
        rowPlace =(int) spaceInformation.rowPlace ;
        colPlace = (int)spaceInformation.colPlace;
        Debug.Log(name + " movement row " + spaceInformation.rowPlace + " col" + spaceInformation.colPlace);

        //todo helper for placement spawn enemy
        finishPosition = new Vector3();
        switch(spaceInformation.direction)
        {
            case "left":
                {
                    finishPosition.x = rowPlace * 8 - 60;
                    finishPosition.z = colPlace * 8 - 8;
                    break;
                }
            case "right":
                {
                    
                    finishPosition.x = rowPlace * 8 - 8;
                    finishPosition.z = colPlace * 8 - 8;
                    break;
                }
        }
        finishPosition.y = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float movement = Time.deltaTime * EnemyHelper.defaultVelocity;
        position = transform.position;

        downMove = position.z >= finishPosition.z ? true : false;

        switch(GetComponent<EnemyInfo>().direction)
        {
            case "left":
                {
                    leftMove = position.x >= finishPosition.x ? false : true;

                    if (downMove)
                    {
                        transform.Translate(0, 0, -movement);
                    }
                    else
                    {

                        if (leftMove)
                        {
                            transform.Translate(movement,0, 0);

                        }
                    }


                    break;
                }
            case "right":
                {
                    //Wylicza czy statek powinien poruszać się w lewo. Jeżeli obecna pozycja jest wieksza od końcowej to się powinien poruszać
                    leftMove = position.x >= finishPosition.x ? true : false;

                    if (downMove)
                    {
                        transform.Translate(0, 0, -movement);
                    }
                    else
                    {
                        if (leftMove)
                        {
                            transform.Translate(-movement, 0, 0);
                        }
                    }
                    break;
                }
        }
    }
}
