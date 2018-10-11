using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marissa : PlayerCharacter
{
    public GameObject bullet_1;
    public GameObject bullet_2;
    private float shotAngle;    // controls what angle the secondary bullets will be shot

    private float shotAngleTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();

        fire_rate_1 = 0.05f;
        next_fire_1 = 0;
        fire_rate_2 = 0.10f;
        next_fire_2 = 0;

        powerupBarrier1 = 5;
        powerupBarrier2 = 10;

        xMin = -3; xMax = 3; yMin = -0.5f; yMax = 8.5f;

        powerupLevel = 0;
        shotAngleTime = 0;

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

        // shoots bullets if the player is holding the space key
        if (Input.GetKey("z"))
        {
            // this makes sure the bullets are fired at a certain rate
            if (Time.time > next_fire_1)
            {
                Fire_Bullet_1();
            }
            // this makes sure the bullets are fired at a certain rate
            if (Time.time > next_fire_2)
            {
                if(powerupLevel >= powerupBarrier1)
                    FireBullet2A();
                if (powerupLevel >= powerupBarrier2)
                    FireBullet2B();
                next_fire_2 = Time.time + fire_rate_2;
            }

            // Here, we update the shot angle for the secondary bullets.  The shots don't rotate in focused mode
            if (!(Input.GetKey(KeyCode.LeftShift)))
                shotAngleTime += Time.deltaTime;

            // this is to make it easier for the player to focus the bullets at a certain angle.  Without this it 
            // feels like there is a delayed effect from holding shift to the angle freezing.
            if (Input.GetKeyDown(KeyCode.LeftShift))
                shotAngleTime -= 0.1f;
        }

        // Calculates the shot angle for the secondary bullets for the next frame.
        shotAngle = 7.5f * Mathf.Sin(3 * shotAngleTime) + 2.5f; // This will always be between -5 and 10 degrees.
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
        Vector3 bullet_position = new Vector3(transform.position.x, transform.position.y + 0.5f, 0);
        Instantiate(bullet_1, bullet_position, Quaternion.identity);
    }

    void FireBullet2A()
    {
        Vector3 bullet_position_1 = new Vector3(transform.position.x + 0.4f, transform.position.y + 0.4f, 0);
        Vector3 bullet_position_2 = new Vector3(transform.position.x - 0.4f, transform.position.y + 0.4f, 0);
        Instantiate(bullet_2, bullet_position_1, Quaternion.Euler(0, 0, -shotAngle));      // swap the negative in the next two lines for a different effect
        Instantiate(bullet_2, bullet_position_2, Quaternion.Euler(0, 0, shotAngle));
    }

    void FireBullet2B()
    {
        Vector3 bullet_position_3 = new Vector3(transform.position.x + 0.6f, transform.position.y + 0.1f, 0);
        Vector3 bullet_position_4 = new Vector3(transform.position.x - 0.6f, transform.position.y + 0.1f, 0);
        Instantiate(bullet_2, bullet_position_3, Quaternion.Euler(0, 0, -2 * shotAngle));    // swap the negative in the next two lines for a different effect
        Instantiate(bullet_2, bullet_position_4, Quaternion.Euler(0, 0, 2 * shotAngle));
    }
}
