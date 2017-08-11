using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletMoveForward : MonoBehaviour {

    // Use this for initialization
    float maxSpeed = 20f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;

        Vector3 velocity = new Vector3(0, 0, maxSpeed * Time.deltaTime);

        position += transform.rotation * velocity;

        transform.position = position;
    }
}
