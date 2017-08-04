using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    
    public GameObject[] meteorPrefabs;
    public float spawnWait=1f; // zmienna wyznaczaja czas miedzy spawnem meteorow
    private int i;
    private int randomizedMeteorNumber;

    void Start()
    {
        InvokeRepeating("SpawnMeteor", 0f, spawnWait);
    }


    //funkcja tworzaca meteory i nadajaca im poczatkowe wartosci polozenia
    void SpawnMeteor()
    {
        randomizedMeteorNumber = Random.Range(0, 5);
        Vector3 meteorSpawnPlace = new Vector3(Random.Range(-130.0f, 120.0f), -30f, 120f); //losuje polozenie meteora troche nad ekranem
        var meteor = Instantiate(meteorPrefabs[randomizedMeteorNumber], meteorSpawnPlace, transform.rotation); //tworzy meteor
        meteor.name = "meteor " + i;
        i++;
    }
}