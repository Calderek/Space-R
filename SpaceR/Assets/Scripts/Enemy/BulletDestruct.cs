using UnityEngine;

public class BulletDestruct : MonoBehaviour
{

    public float timer = 6f;  // czas po jakim pocisk znika

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}

