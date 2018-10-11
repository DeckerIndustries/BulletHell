using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Blue_Script : MonoBehaviour
{
    public GameObject bullet;
    public GameObject powerup;
    public int hp;             // hit points

    private Rigidbody2D rb;
    private float powerupDropRate;
    private int xSpeed;
    private float nextFire;
    private float fireRate;

    // Use this for initialization
    void Start ()
    {
        xSpeed = -2;
        nextFire = 0;
        fireRate = 0.75f;
        powerupDropRate = 0.25f;    // the percent chance this ship will drop a powerup when it dies.

        // gets this object's rigidbody
        rb = GetComponent<Rigidbody2D>();

        // if the ships start off to the left of the screen, we want them to move right.  If it starts to the right of the screen, it should move left.
        if (rb.position.x < 0)
            xSpeed = 2;
        else if (rb.position.x > 0)
            xSpeed = -2;

        // moves the ship to the left accross the screen
        rb.velocity = new Vector2(xSpeed, 0);
    }
	
	// Update is called once per frame
	void Update ()
    {
        // checks if the bullet left the boundary of the game
        if (ExitBoundary() == true)
            Destroy(gameObject);

        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, transform.position, Quaternion.identity);
        }

        // once this ship reaches a certain point on the screen, it stops.
        if (rb.velocity.x > 0)
        {
            if (rb.position.x >= -2.5)
                rb.velocity = new Vector2(0, 0);
        }
        else if (rb.velocity.x < 0)
        {
            if (rb.position.x <= 2.5)
                rb.velocity = new Vector2(0, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player_Bullet")
        {
            hp -= other.GetComponent<Damage>().damage;

            if (hp <= 0)
            {
                float randNum = Random.value;   // random number between 0 and 1
                if (randNum < powerupDropRate)
                    Instantiate(powerup, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            Destroy(other.gameObject);
        }
    }

    // checks if the the bullet left the boundary of our game (which I decided to be slightly larger than the part the camera sees)
    bool ExitBoundary()
    {
        if (rb.position.x < -4 || rb.position.x > 4 || rb.position.y < -1.5 || rb.position.y > 9.5)
            return true;
        else
            return false;
    }

    void OnDestroy()
    {
        
    }
}
