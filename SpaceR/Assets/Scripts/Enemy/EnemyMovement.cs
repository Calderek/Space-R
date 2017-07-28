using UnityEngine;

public class EnemyMovement : MonoBehaviour {


    private Vector3 position;
    private Vector3 finishPosition;

    private bool leftMove = false;
    private bool downMove = false;
    private int rowPlace;
    private int colPlace;


    // Use this for initialization
    // Use this for initialization
    void Start()
    {

        var spaceInformation = GetComponent<EnemyInfo>();
        rowPlace = spaceInformation.rowPlace;
        colPlace = spaceInformation.colPlace;
        Debug.Log("Statek " + name + " ma być ustawiony w" + rowPlace + "rzedzie oraz " + colPlace + " kolumnie");
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

        position = transform.position;
        downMove = position.z <= finishPosition.z ? false : true;
        Debug.Log(position.z + "   " + finishPosition.z);
        leftMove = position.x <= finishPosition.x ? false : true;

        float movement = Time.deltaTime * 5;

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

    }
}
