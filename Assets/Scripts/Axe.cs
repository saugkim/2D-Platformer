using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "Player" && collision.gameObject.tag != "Axewalkable")
        {
            Destroy(gameObject.GetComponent<Rigidbody2D>());
         
         //   Destroy(gameObject.GetComponent<BoxCollider2D>());
            gameObject.GetComponent<BoxCollider2D>().isTrigger= false;
            gameObject.tag = "Axewalkable";
            gameObject.layer = 10;

            gameObject.transform.parent = collision.gameObject.transform;

        }
    }
}
