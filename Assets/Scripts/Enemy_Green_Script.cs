using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Green_Script : MonoBehaviour
{
    public GameObject bullet;
    public GameObject powerup;
    public int hp;

    private int speed;
    private float powerupDropRate;
    private Rigidbody2D rb;
    private float nextFire;
    private float fireRate;

	// Use this for initialization
	void Start ()
    {
        speed = 2;
        nextFire = 0;
        fireRate = 0.7f;
        powerupDropRate = 0.25f;

        // gets this object's rigidbody
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = new Vector2(speed, 0);
	}
	
	// Update is called once per frame
	void Update ()
    {
        // checks if the bullet left the boundary of the game
        if (ExitBoundary() == true)
            Destroy(gameObject);

        // fires the bullet every "fireRate" seconds.
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        // takes damage if hit by the player's bullet
        if(other.tag == "Player_Bullet")
        {
            hp -= other.GetComponent<Damage>().damage;

            if (hp <= 0)
                Destroy(gameObject);
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
        float randNum = Random.value;   // random number between 0 and 1
        if (randNum < powerupDropRate)
            Instantiate(powerup, transform.position, Quaternion.identity);
    }
}
