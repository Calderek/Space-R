using UnityEngine;
using Assets.Helper;

public class MeteorMovement : MonoBehaviour
{

    private float meteorSpeed;

    private float meteorRotationX;
    private float meteorRotationY;
    private float meteorRotationZ;

    private BackgroundMovementInfo backgroundMovementInfo;
    private Vector3 position;

    void Start ()
    {
        var meteorInformation = GetComponent<BackgroundMovementInfo>();
        meteorRotationX = meteorInformation.objectRotationX;
        meteorRotationY = meteorInformation.objectRotationY;
        meteorRotationZ = meteorInformation.objectRotationZ;
        meteorSpeed = meteorInformation.objectSpeed;
    }
    void Update()
    {
        position = transform.position;
        transform.Translate(0, 0, -1 * meteorSpeed *Time.deltaTime, Space.World);
        transform.Rotate(meteorRotationX * Time.deltaTime, meteorRotationY * Time.deltaTime, meteorRotationZ * Time.deltaTime);
        if (transform.position.z < -150f && transform.position.z>-160f)
        {
            Destroy(gameObject);
        }
    }
   
   
}