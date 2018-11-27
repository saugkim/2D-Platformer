using UnityEngine;

public class Bonfire : MonoBehaviour {

    private GameObject player;

    public float bonfireRadius = 5;

	void Start ()
    {
        player = GameObject.Find("CharacterContainer");
	}

	void FixedUpdate ()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, player.transform.position);
        if(hit.distance < bonfireRadius)
        {
            Debug.Log("close enough");
            CharacterMovement playerinfo = player.GetComponent<CharacterMovement>();

            if(playerinfo.currentHealth < playerinfo.maxHealth)
            {
                playerinfo.currentHealth += 0.1f;
            }
        }

        else
        {
            Debug.Log("too far away");
        }
	}
}
