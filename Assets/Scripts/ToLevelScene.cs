using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToLevelScene : MonoBehaviour {

    public string level; // What level we want to load
    public GameObject spawnPoint; 
    // Where we want to spawn when we come back from the level


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Player near level object. 
            // Add Spawnpoint to gameStatus and change scene 
            GameStatus.storedSpawnPoint = spawnPoint.name;
            Debug.Log("Saved Spawn point: " + 
                GameStatus.storedSpawnPoint);
            SceneManager.LoadScene(level);
        }
    }

}
