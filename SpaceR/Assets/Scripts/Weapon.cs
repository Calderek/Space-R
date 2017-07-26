using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public GameObject m_BulletPrefab;
    public Transform m_BulletSpawnPoint;

    public float m_Speed = 30;
    public float m_LifeTime = 0.5f;
    public float m_FireRate = 0.5f;

    private bool m_CanShoot = true;


    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKey(KeyCode.Space) && m_CanShoot)
        {
            StartCoroutine(Fire());
            
        }
    }

    public IEnumerator Fire()
    {
        var bullet = (GameObject)Instantiate(m_BulletPrefab, m_BulletSpawnPoint.position, m_BulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * m_Speed;

        m_CanShoot = false;
        yield return new WaitForSeconds(m_FireRate);
        m_CanShoot = true;
        Destroy(bullet, m_LifeTime);
    }
}
