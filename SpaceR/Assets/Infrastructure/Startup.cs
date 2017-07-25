using UnityEditor;
using UnityEngine;


/// <summary>
/// Klasa wywołuje kod w statycznym konstruktorze dokładnie raz podczas uruchomienia projektu
/// </summary>

[InitializeOnLoad]
public class Startup {

    // Use this for initialization
    static Startup()
    {
        EnemiesCreate creator = new EnemiesCreate();
        creator.Create();
    }
}
