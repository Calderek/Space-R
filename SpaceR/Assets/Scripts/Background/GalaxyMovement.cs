using UnityEngine;
using Assets.Helper;

public class GalaxyMovement : MonoBehaviour
{

    private float galaxySpeed;

    private float galaxyRotationY;

    private BackgroundMovementInfo backgroundMovementInfo;
    private Vector3 position;

    void Start()
    {
        var galaxyInformation = GetComponent<BackgroundMovementInfo>();
        galaxyRotationY = galaxyInformation.objectRotationY;
        galaxySpeed = galaxyInformation.objectSpeed;
    }
    void Update()
    {
        position = transform.position;
        transform.Translate(0, 0, -1 * galaxySpeed * Time.deltaTime, Space.World);
        transform.Rotate(0f, galaxyRotationY * Time.deltaTime, 0f);

        if (transform.position.z < -200f && transform.position.z > -210f)
        {
            Destroy(gameObject);
        }
    }


}