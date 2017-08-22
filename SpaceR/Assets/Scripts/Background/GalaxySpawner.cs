using UnityEngine;
using Assets.Helper;

public class GalaxySpawner : MonoBehaviour
{

    public GameObject[] galaxyPrefabs;
    public float spawnWait = 100f; // zmienna wyznaczajaca czas miedzy spawnem mgławic
    private int i=0;
    private int randomizedGalaxyNumber; // do losowania jednej z mgławic z puli Prefabow
    private BackgroundMovementInfo galaxyMovementInfo;
    private float xRangeLeft, xRangeRight, zRangeUp, zRangeDown; // Zmienne do ustalenia granic pozycji losowanych mgławic

    void Start()
    {
        //Towrzy pierwsze 2 mglawice na planszy
        xRangeLeft = -200f;
        xRangeRight = 200f;
        zRangeUp = 240f;
        zRangeDown = -90f;
        for (int a = 0; a < 6; a++)
        {
            SpawnGalaxy();
        }

        //Inicjuje Tworzenie sie gwiazd i generowanie mglawic co spawnWait
        zRangeDown = 280f;
        zRangeUp = 280f;
        InvokeRepeating("SpawnGalaxy", 0f, spawnWait);
        InvokeRepeating("SpawnGalaxy", 0f, spawnWait);
    }


    //funkcja tworzaca mglawice i nadajaca im poczatkowe wartosci polozenia
    void SpawnGalaxy()
    {
        randomizedGalaxyNumber = Random.Range(0, 5);

        //losuje polozenie mglawic
        Vector3 galaxySpawnPlace = new Vector3(Random.Range(xRangeLeft, xRangeRight), -39f, Random.Range(zRangeDown, zRangeUp));

        //tworzy mglawice
        var galaxy = Instantiate(galaxyPrefabs[randomizedGalaxyNumber], galaxySpawnPlace, transform.rotation);

        galaxyMovementInfo = galaxy.GetComponent<BackgroundMovementInfo>();

        //Ustawienie nazwy mglawicy
        galaxy.name = "galaxy " + i;
        i++;

        //ustawienie rozmiaru mglawicy 
        galaxyMovementInfo.objectSize = Random.Range(BackgroundHelper.minGalaxySize, BackgroundHelper.maxGalaxySize);
        galaxy.transform.localScale = new Vector3(galaxyMovementInfo.objectSize, galaxyMovementInfo.objectSize, galaxyMovementInfo.objectSize);

        //Ustawienie początkowego obrotu mglawicy
        galaxy.transform.eulerAngles = new Vector3(0f, Random.Range(0f, 100f), 0f);

        //Ustawienie losowej predkosci rotacji dla mglawicy
        galaxyMovementInfo.objectRotationX = 0f;
        galaxyMovementInfo.objectRotationY = Random.Range(0f, 1f);
        galaxyMovementInfo.objectRotationZ = 0f;

        //ustawienie predkosci mglawicy

        galaxyMovementInfo.objectSpeed = Random.Range(BackgroundHelper.minGalaxySpeed, BackgroundHelper.maxGalaxySpeed);
    }
}