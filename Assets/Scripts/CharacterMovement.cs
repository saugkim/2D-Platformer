using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class CharacterMovement : MonoBehaviour {

    public float movementSpeed;
    public float jumpForce;

    public Animator animator;

    public Rigidbody2D rb2D;

    public float currentHealth;
    public float previousHealth;
    public float maxHealth;
    public float counter;
    public float maxCounter;
    public Image healthBar;

    public GameObject bonfireEffect;
    public bool isGrounded = true;

    [SerializeField]
  //  private GameObject _axe;

    public GameObject axe;
    public int axeAmount;
    public float throwForce;


	void Start () {

        currentHealth = maxHealth;
        previousHealth = maxHealth;

        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();

//        StartCoroutine(CheckForCollision());
	}

    
    void Update ()
    {
        PlayerWalk();

        PlayerChangeDirection();

        PlayerJump();

        ShowHealthBar();

        MakeBonfire();

        ThrowAxe();
    } 

    private void ThrowAxe()
    {
        if (Input.GetButtonDown("Fire1") && axeAmount > 0)
        {

            axeAmount--;
            GameObject axeClone = Instantiate(axe, gameObject.transform.position, Quaternion.identity);
            axeClone.GetComponent<Rigidbody2D>().AddForce
                (new Vector2(gameObject.transform.localScale.x * throwForce, throwForce), ForceMode2D.Impulse);

            axeClone.GetComponent<Rigidbody2D>().AddTorque(-400 * gameObject.transform.localScale.x);

        }
    }

    private void MakeBonfire()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Vector2 newPosition = new Vector2(transform.position.x + 10 * transform.localScale.x, 
                                              GameObject.Find("Foot_L").transform.position.y);
            Instantiate(bonfireEffect, newPosition, Quaternion.identity);
        }
    }

    private void ShowHealthBar()
    {
        if (counter < maxCounter)
        {
            counter += Time.deltaTime;
        }
        else
        {
            previousHealth = currentHealth;
            counter = 0;
        }

        healthBar.fillAmount = Mathf.Lerp(previousHealth/maxHealth, currentHealth/maxHealth, counter/maxCounter);
    }

    private void PlayerWalk()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            animator.SetBool("Walk", true);
            transform.Translate(new Vector2(Input.GetAxis("Horizontal") *
                movementSpeed * Time.deltaTime, 0));
        }
        else
        {
            animator.SetBool("Walk", false);
        }
    }


    private void PlayerChangeDirection()
    {
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            animator.SetTrigger("Jump");
            rb2D.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);

            isGrounded = false;

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Axewalkable"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Axewalkable"))
        {
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(20f);
        }
    }

    void TakeDamage(float dmg)
    {
        counter = 0;
        previousHealth = healthBar.fillAmount * maxHealth;
        currentHealth -= dmg;
    }

}


// if()
/*
Homework/Schoolwork
Create 3 different small!! levels (scenes)
Create a small particle effect to the end of each the level
Create an IceCube (tagged as "Enemy") to some place in the level
Create a "WorldMap" Scene, where is Map.png and background
Create a "MapPlayer" use MapIcon.png. 
Player moves using w,a,s,d on map

Next time we'll do following:
Dynamic Health Bar for the character
Scene change from map to levels and back to map


Homework!
Fix jump bug, so player cannot jump in the air (OK)
(put empty gameobject to the feet of the player and check when
empty gameobject is contacting with the ground. Only then jumping
is possible)

// make new class name Axe
Make player to throw an axe when pressed left-ctrl (instansiate)
Make the axe to rotate in the air (transform.rotate)
Make the axe to attach to the object it hits (remove rigidbody component)
Make limit to amount of axes and number to the UI

Make user to light up a bonfire by pressing f-button
This means you need to instance the bonfire prefab
Turn on particle affect and a light (included in the prefab)
If player is near the fireplace health is increasing slowly


*/

