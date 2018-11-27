using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Player has hit the particle effect -> to WorldMap
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("WorldMap");

        }
    }

}
