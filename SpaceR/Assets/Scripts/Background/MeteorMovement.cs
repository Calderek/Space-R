using UnityEngine;
using Assets.Helper;

public class MeteorMovement : MonoBehaviour
{

    private float meteorSpeed;
    //  public float minMeteorSpeed = 5f;
    //  public float maxMeteorSpeed = 20f;

    private float meteorRotationX;
    private float meteorRotationY;
    private float meteorRotationZ;

    //   public float minMeteorSize = 5f;
    //   public float maxMeteorSize = 20f;

    private float meteorSize;
    private MeteorMovementInfo meteorMovementInfo;
    private Vector3 position;

    void Start ()
    {
        var meteorInformation = GetComponent<MeteorMovementInfo>();
        meteorRotationX = meteorInformation.meteorRotationX;
        meteorRotationY = meteorInformation.meteorRotationY;
        meteorRotationZ = meteorInformation.meteorRotationZ;
        meteorSpeed = meteorInformation.meteorSpeed;
        meteorSize = meteorInformation.meteorSize;





        /* 
             meteorSize = Random.Range(minMeteorSize, maxMeteorSize);

             //Jezeli rozmiar meteora jest duzy to bedzie poruszac sie szybko na 1 planie, mniejsze meteory beda poruszac sie w tle z mniejsza predkoscia (iluzja glebi)
             if (meteorSize>13f)
             {
                 meteorSpeed = Random.Range(minMeteorSpeed*2f, maxMeteorSpeed);
                 transform.position = new Vector3(transform.position.x, -15f, transform.position.z);
             }
             else
             {
                 meteorSpeed = Random.Range(minMeteorSpeed, maxMeteorSpeed / 2f);
                 transform.position = new Vector3(transform.position.x, -30f, transform.position.z);
             } 

             transform.localScale = new Vector3(meteorSize, meteorSize, meteorSize);
             meteorRotationX = Random.Range(25f, 50f);
             meteorRotationY = Random.Range(25f, 50f);
             meteorRotationZ = Random.Range(25f, 50f);

         */
    }
    void Update()
    {
        position = transform.position;
        transform.Translate(0, 0, -1 * meteorSpeed *Time.deltaTime, Space.World);
        transform.Rotate(meteorRotationX * Time.deltaTime, meteorRotationY * Time.deltaTime, meteorRotationZ * Time.deltaTime);
        Destroy(gameObject, 50);
    }
   
   
}