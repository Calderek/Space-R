using Assets.Helper;
using Assets.LogicModel.Enemy;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private Vector3 position;
    private Vector3 finishPosition;

    private bool leftMove = false;
    private bool downMove = false;

    private EnemyMapPosition targetPosition;


    private bool isFinishPosition;

    private EnemyVibration vibration;


    void Start()
    {
        InitializeMovementControl();
        SetTargetPosition();
    }


    void Update()
    {
        if (isFinishPosition)
        {
            if(EnemyHelper.vibrateEnable)
                VibrateShip();
            return;
        }

        float movement = Time.deltaTime * EnemyHelper.defaultVelocity;
        position = transform.position;

        downMove = position.z >= targetPosition.Z ? true : false;
        isFinishPosition = !downMove && !leftMove ? true : false;
        switch (GetComponent<EnemyInfo>().direction)
        {
            case "left":
                {
                    leftMove = position.x >= targetPosition.X ? false : true;

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
                    leftMove = position.x >= targetPosition.X ? true : false;

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

    private void InitializeMovementControl()
    {
        //When spaceship was created, it can't be in target position. It first must arrive to end position
        isFinishPosition = false;
        InitializeVibrationControl();

    }

    /// <summary>
    /// Set controls about vibration enable mode
    /// </summary>
    private void InitializeVibrationControl()
    {
        vibration = new EnemyVibration();
        vibration.Enable = true;

    }

    private void SetTargetPosition()
    {
        targetPosition = new EnemyMapPosition();
        var spaceInformation = GetComponent<EnemyInfo>();
        targetPosition.RowPlace = (int)spaceInformation.rowPlace;
        targetPosition.ColPlace = (int)spaceInformation.colPlace;
        targetPosition.SetPositionFromMatrixPlace(spaceInformation.direction);
    }

    /// <summary>
    /// Slightly move shipspace when was in target place
    /// </summary>
    private void VibrateShip()
    {
        if (vibration.Enable)
        {
            vibration.EnemyPosition = transform.position;
            vibration.Vibrate();
        }
        transform.Translate(vibration.DirectionX * Time.deltaTime * vibration.HorizontalVelocity, 0, vibration.DirectionZ * Time.deltaTime * vibration.VerticalVelocity);
    }



    


   



}
