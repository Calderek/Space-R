using UnityEngine;
using System.Linq;

public class EnemyDestruction : MonoBehaviour {

    private EnemyInfo info;
    private WeaponList list;
    private string oCollider;
    private int oDamage;

    public ParticleSystem explosionPrefab;
    

	// Use this for initialization
	void Start () {
        var armory = GameObject.FindWithTag("Armory");
        list = armory.GetComponent<WeaponList>();

        info = GetComponent<EnemyInfo>();
	}

    private void OnCollisionEnter(Collision coll)
    {
        var hit = coll.collider.tag;

        //Debug.Log("Otrzymano trafienie.");
        for(int i = 0; i < list.weaponList.Count; i++)
        {
            
            oCollider = list.weaponList.Select(x => list.weaponList[i].Weapon.tag).First();
            oDamage = list.weaponList.Select(x => list.weaponList[i].Damage).First();

            if (hit == oCollider)
            {
                Debug.Log("Trafienie weszło za " + oDamage);
                info.health -= oDamage;
                break;
            }
            else if (hit == "Player")
                info.health = 0;
        }

        if(info.health <= 0 )
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
