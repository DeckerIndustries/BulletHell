using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReimuController : PlayerCharacter
{
    public GameObject bullet_1;
    public GameObject bullet_1B;
    public GameObject bullet_2;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();

        fire_rate_1 = 0.05f;
        next_fire_1 = 0;
        fire_rate_2 = 0.25f;
        next_fire_2 = 0;

        powerupBarrier1 = 10;
        powerupBarrier2 = 20;
        powerupLevel = 0;

        xMin = -3; xMax = 3; yMin = -0.5f; yMax = 8.5f;

        focussedSpeed = 3;
        nonFocussedSpeed = 6;
    }

    void FixedUpdate()
    {

        // slow down ship if shift is pressed down
        if (Input.GetKey(KeyCode.LeftShift))
            MovePlayer(focussedSpeed);
        else
            MovePlayer(nonFocussedSpeed);

        // shoots bullets if the player is holding the z key
        if (Input.GetKey("z"))
        {
            // this makes sure the bullets are fired at a certain rate
            if (Time.time > next_fire_1)
            {
                FireBullet1A();

                // only fire this one when we have collected enough powerups
                if (powerupLevel >= powerupBarrier1)
                    FireBullet1B();

                next_fire_1 = Time.time + fire_rate_1;
            }

            if (Time.time > next_fire_2)
            {
                if (powerupLevel >= powerupBarrier2)
                {
                    FireBullet2();
                }

                next_fire_2 = Time.time + fire_rate_2;
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

    void FireBullet1A()
    {
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

    void FireBullet1B()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Vector3 bullet_position_B1 = new Vector3(transform.position.x + 0.4f, transform.position.y + 0.5f, 0);
            Vector3 bullet_position_B2 = new Vector3(transform.position.x - 0.4f, transform.position.y + 0.5f, 0);
            Instantiate(bullet_1B, bullet_position_B1, Quaternion.identity);
            Instantiate(bullet_1B, bullet_position_B2, Quaternion.identity);
        }
        else
        {
            Vector3 bullet_position_B1 = new Vector3(transform.position.x + 0.6f, transform.position.y + 0.1f, 0);
            Vector3 bullet_position_B2 = new Vector3(transform.position.x - 0.6f, transform.position.y + 0.1f, 0);
            Instantiate(bullet_1B, bullet_position_B1, Quaternion.identity);
            Instantiate(bullet_1B, bullet_position_B2, Quaternion.identity);
        }
    }

    void FireBullet2()
    {
        Vector3 bullet_position = new Vector3(transform.position.x, transform.position.y + 0.7f, 0);
        Instantiate(bullet_2, bullet_position, Quaternion.identity);
    }
}

