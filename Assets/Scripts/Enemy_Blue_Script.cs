using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Blue_Script : MonoBehaviour
{
    public int speed;
    public GameObject bullet;

    private Rigidbody2D rb;
    private float nextFire;
    private float fireRate;
    public int hp;             // hit points

    // Use this for initialization
    void Start ()
    {
        speed = -2;
        hp = 20;
        nextFire = 0;
        fireRate = 0.25f;

        // gets this object's rigidbody
        rb = GetComponent<Rigidbody2D>();

        // moves the ship to the left accross the screen
        rb.velocity = new Vector2(speed, 0);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player_Bullet")
        {
            hp -= other.GetComponent<Damage>().damage;

            if(hp <= 0)
                Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

    // destroys the object if the ship leaves the camera view
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
