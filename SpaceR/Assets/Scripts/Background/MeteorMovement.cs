using UnityEngine;
using Assets.Helper;

public class MeteorMovement : MonoBehaviour
{

    private float meteorSpeed;

    private float meteorRotationX;
    private float meteorRotationY;
    private float meteorRotationZ;

    private MeteorMovementInfo meteorMovementInfo;
    private Vector3 position;

    void Start ()
    {
        var meteorInformation = GetComponent<MeteorMovementInfo>();
        meteorRotationX = meteorInformation.meteorRotationX;
        meteorRotationY = meteorInformation.meteorRotationY;
        meteorRotationZ = meteorInformation.meteorRotationZ;
        meteorSpeed = meteorInformation.meteorSpeed;
    }
    void Update()
    {
        position = transform.position;
        transform.Translate(0, 0, -1 * meteorSpeed *Time.deltaTime, Space.World);
        transform.Rotate(meteorRotationX * Time.deltaTime, meteorRotationY * Time.deltaTime, meteorRotationZ * Time.deltaTime);
        Destroy(gameObject, 50);
    }
   
   
}