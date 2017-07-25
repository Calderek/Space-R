using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class EnemiesCreate {


    public void Create()
    {
        //Material newMat = Resources.Load("Assets/Models/Materials/Material", typeof(Material)) as Material;
        for(int i=0;i<16;i++)
        {
            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.name = "enemy " + (i + 1)  ;
            cube.transform.position = new Vector3(16.98284F, 1.232025F, 8*i);
            //GameObject prefab = AssetDatabase.LoadAssetAtPath("Assets/Models/spaceship", typeof(GameObject));
            //GameObject clone = GameObject.Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;
            //cube.GetComponent<Renderer>().material = newMat;
            GameObject go = new GameObject("spaceship");
            //go.name = "nazwa";
        }

    }
     

}
