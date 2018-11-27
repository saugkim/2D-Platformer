using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class mapPlayer : MonoBehaviour {

    public float movementSpeed; 
    
	// Use this for initialization
	void Start () {
        if (GameStatus.storedSpawnPoint != null)
        {
            // Check if we need to go to spawnpoint
            Debug.Log(GameStatus.storedSpawnPoint);
            transform.position =  GameObject.Find(GameStatus.storedSpawnPoint).transform.position;
        }
	}
	
	// Update is called once per frame
	void Update () {

        float horizontal = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;

        transform.Translate(new Vector3(horizontal, vertical, 0));
	}
}
