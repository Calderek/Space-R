﻿using UnityEngine;
using Assets.Helper;

public class MeteorSpawner : MonoBehaviour
{
    
    public GameObject[] meteorPrefabs;
    public GameObject starsPrefabs;
    public float spawnWait=0.5f; // zmienna wyznaczajaca czas miedzy spawnem meteorow
    private int i;
    private int randomizedMeteorNumber; // do losowania jednego z meteorow z puli Prefabow
    private MeteorMovementInfo meteorMovementInfo;
    private float xRangeLeft, xRangeRight, zRangeUp, zRangeDown; // Zmienne do ustalenia granic pozycji losowanych meteorów

    void Start()
    {
        //Towrzy pierwsze 30 meteorow na planszy
        xRangeLeft = -170f;
        xRangeRight = 170f;
        zRangeUp = 120f;
        zRangeDown = -90f;
        for(int a=0; a<30; a++)
        {
            SpawnMeteor();
        }

        //Inicjuje Tworzenie sie gwiazd i generowanie meteorow co spawnWait
        zRangeDown = 120f;
        var stars = Instantiate(starsPrefabs);
        InvokeRepeating("SpawnMeteor", 0f, spawnWait);
    }


    //funkcja tworzaca meteory i nadajaca im poczatkowe wartosci polozenia
    void SpawnMeteor()
    {
        randomizedMeteorNumber = Random.Range(0, 5);
       
        //losuje polozenie meteora troche nad ekranem
        Vector3 meteorSpawnPlace = new Vector3(Random.Range(xRangeLeft, xRangeRight), -30f, Random.Range(zRangeDown, zRangeUp));

        //tworzy meteor
        var meteor = Instantiate(meteorPrefabs[randomizedMeteorNumber], meteorSpawnPlace, transform.rotation);


        meteorMovementInfo = meteor.GetComponent<MeteorMovementInfo>();

        //Ustawienie nazwy meteora
        meteor.name = "meteor " + i;
        i++;

        //ustawienie rozmiaru meteora 
        meteorMovementInfo.meteorSize = Random.Range(MeteorHelper.minMeteorSize, MeteorHelper.maxMeteorSize);
        meteor.transform.localScale = new Vector3(meteorMovementInfo.meteorSize, meteorMovementInfo.meteorSize, meteorMovementInfo.meteorSize);

        //Ustawienie pozycji na osi Y i predkosci meteora
        //Jezeli rozmiar meteora jest duzy to bedzie poruszac sie szybko na 1 planie, mniejsze meteory beda poruszac sie w tle z mniejsza predkoscia (iluzja glebi)
        if (meteorMovementInfo.meteorSize > 13f)
        {
            meteorMovementInfo.meteorSpeed = Random.Range(MeteorHelper.minMeteorSpeed * 2f, MeteorHelper.maxMeteorSpeed);
            meteor.transform.position = new Vector3(meteor.transform.position.x, -15f, meteor.transform.position.z);
        }
        else
        {
            meteorMovementInfo.meteorSpeed = Random.Range(MeteorHelper.minMeteorSpeed, MeteorHelper.maxMeteorSpeed / 2f);
            meteor.transform.position = new Vector3(meteor.transform.position.x, -30f, meteor.transform.position.z);
        }

        //Ustawienie losowej rotacji dla meteora
        meteorMovementInfo.meteorRotationX = Random.Range(25f, 50f);
        meteorMovementInfo.meteorRotationY = Random.Range(25f, 50f);
        meteorMovementInfo.meteorRotationZ = Random.Range(25f, 50f);
    }
}