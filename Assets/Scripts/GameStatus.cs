using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour {

    public static string storedSpawnPoint; 

	// Use this for initialization
	void Awake ()
    {
        DontDestroyOnLoad(gameObject);
	}
	
}
