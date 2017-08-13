using Assets.Helper;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{


    private Vector3 position;
    private Vector3 finishPosition;

    private bool leftMove = false;
    private bool downMove = false;
    private int rowPlace;
    private int colPlace;
    private bool isFinishPosition;


    private bool changeZDirection;
    private bool changeXDirection;
    private int movementZIndexer;
    private int movementXIndexer;

    private int directionX;
    private int directionZ;

    private Random dictionaryMovementGenerator;
    // Use this for initialization
    void Start()
    {
        directionX = 0;
        directionZ = 0;
        isFinishPosition = false;
        changeXDirection = true;
        changeZDirection = true;
        movementXIndexer = 0;
        movementZIndexer = 0;
        dictionaryMovementGenerator = new Random();

        var spaceInformation = GetComponent<EnemyInfo>();
        rowPlace = (int)spaceInformation.rowPlace;
        colPlace = (int)spaceInformation.colPlace;
        Debug.Log(name + " movement row " + spaceInformation.rowPlace + " col" + spaceInformation.colPlace);

        //todo helper for placement spawn enemy
        finishPosition = new Vector3();
        switch (spaceInformation.direction)
        {
            case "left":
                {
                    finishPosition.x = -rowPlace * 8 - 16;
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
        if (isFinishPosition)
        {

            if (changeXDirection)
            {
                directionX = Random.Range(0, 1000) % 2 == 0 ? 1 : -1;
                movementXIndexer = 0;
            }

            if (changeZDirection)
            {
                directionZ = Random.Range(0, 1000) % 2 == 0 ? 1 : -1;
                movementZIndexer = 0;
            }


            changeXDirection = movementXIndexer >= 100 ? true : false;
            changeZDirection = movementZIndexer >= 200 ? true : false;
            movementXIndexer++;
            movementZIndexer++;


            transform.Translate(directionX * Time.deltaTime * 3, 0, directionZ * Time.deltaTime * 2);
            return;
        }

        float movement = Time.deltaTime * EnemyHelper.defaultVelocity;
        position = transform.position;

        downMove = position.z >= finishPosition.z ? true : false;
        isFinishPosition = !downMove && !leftMove ? true : false;
        switch (GetComponent<EnemyInfo>().direction)
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
                            transform.Translate(movement, 0, 0);

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
