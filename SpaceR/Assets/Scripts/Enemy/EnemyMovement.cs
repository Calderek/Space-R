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
        //position = transform.position;
        //Debug.Log("Startowa pozycja statku" + name + " to x: " + position.x + " z: " + position.z);

        //todo helper for placement spawn enemy
        finishPosition = new Vector3();
        finishPosition.x = rowPlace * 8 - 8;
        finishPosition.z = colPlace * 8 - 8;
        Debug.Log("Końcowa pozycja statku" + name + " to x: " + finishPosition.x + " z: " + finishPosition.z);

        finishPosition.y = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float movement = Time.deltaTime * EnemyHelper.defaultVelocity;
        position = transform.position;
        Debug.Log("Obecna pozycja statku" + name + " to x: " + position.x + " z: " + position.z);

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
                    Debug.Log("pozycja statku w sprawdzaniu warunku na poruszenie sie na boki " + name + " to x: " + position.x + " <=: " + finishPosition.z + " "+ leftMove);


                    if (downMove)
                    {
                        //Debug.Log("Tu sie poruszam w dół");
                        transform.Translate(0, 0, -movement);
                    }
                    else
                    {
                        if (leftMove)
                        {
                            transform.Translate(-movement, 0, 0);
                            Debug.Log("Tu sie poruszam w lewo");

                        }
                    }
                    break;
                }
        }
    }
}
