using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Transform playerPosition;

    public float smoothTime;
    private Vector3 velocity = Vector3.zero;

    void Start () {

       // playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 targetPosition = new Vector3(playerPosition.position.x, 
            playerPosition.position.y, -10);

        transform.position = Vector3.SmoothDamp(transform.position, 
            targetPosition, ref velocity, smoothTime);


    }
}
