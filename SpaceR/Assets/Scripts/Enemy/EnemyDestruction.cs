using UnityEngine;

public class EnemyDestruction : MonoBehaviour {

    private EnemyInfo info;
    public ParticleSystem explosionPrefab;

	// Use this for initialization
	void Start () {
        info = GetComponent<EnemyInfo>();
	}
	

    void OnCollisionEnter(Collision coll)
    {
        Bullet bullet = coll.collider.GetComponent<Bullet>() as Bullet;
        RocketController rocket = coll.collider.GetComponent<RocketController>() as RocketController;
        if(bullet || rocket != null)
        {
            info.health--;
        }
        if(info.health <=0)
        {
            Explode();
        }
    }

    void Explode()
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }

}
