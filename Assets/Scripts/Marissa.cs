using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marissa : PlayerCharacter
{
    public GameObject bullet_1;
    //public GameObject bullet_1B;
    //public GameObject bullet_2;

    //private float fire_rate_1;
    //private float next_fire_1;
    //private int powerupBarrier1;
    //private float fire_rate_2;
    //private float next_fire_2;
    //private int powerupBarrier2;
    private float speed;
    //private float xVelocity, yVelocity;
    //private float posX, posY;
    //private float xMin = -3, xMax = 3, yMin = -0.5f, yMax = 8.5f;
    //private float powerupLevel;
    //private Rigidbody2D rb;     // this is the player object.
    //private Animator animator;  // controlls animation

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();

        fire_rate_1 = 0.05f;
        next_fire_1 = 0;
        //fire_rate_2 = 0.25f;
        //next_fire_2 = 0;

        //powerupBarrier1 = 10;
        //powerupBarrier2 = 20;
        powerupLevel = 0;
    }

    void FixedUpdate()
    {

        // slow down ship if shift is pressed down
        if (Input.GetKey(KeyCode.LeftShift))
            MovePlayer(focussedSpeed);
        else
            MovePlayer(nonFocussedSpeed);

        // shoots bullets if the player is holding the space key
        if (Input.GetKey("z"))
        {
            // this makes sure the bullets are fired at a certain rate
            if (Time.time > next_fire_1)
            {
                Fire_Bullet_1();
            }
        }
    }

    // only powerups collide with the player (bullets collide with the hitbox)
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Powerup")
        {
            powerupLevel += 5;
            Destroy(other.gameObject);
        }
    }

    void Fire_Bullet_1()
    {
        next_fire_1 = Time.time + fire_rate_1;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Vector3 bullet_position_A1 = new Vector3(transform.position.x + 0.2f, transform.position.y + 0.5f, 0);
            Vector3 bullet_position_A2 = new Vector3(transform.position.x - 0.2f, transform.position.y + 0.5f, 0);
            Instantiate(bullet_1, bullet_position_A1, Quaternion.identity);
            Instantiate(bullet_1, bullet_position_A2, Quaternion.identity);
        }
        else
        {
            Vector3 bullet_position_A1 = new Vector3(transform.position.x + 0.4f, transform.position.y + 0.3f, 0);
            Vector3 bullet_position_A2 = new Vector3(transform.position.x - 0.4f, transform.position.y + 0.3f, 0);
            Instantiate(bullet_1, bullet_position_A1, Quaternion.identity);
            Instantiate(bullet_1, bullet_position_A2, Quaternion.identity);
        }
    }
}
