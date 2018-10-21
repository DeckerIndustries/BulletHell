using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHelperL : MonoBehaviour
{
    private float topBoundary = 8.75f;
    private float bottomBoundary = -0.75f;

    private int phase;
    private float yVelocity0;   // y velocity for phase 0
    private float yVelocity1;   // y velocity for phase 1
    private float startTime;
    private float nextFire;
    private float fireRate1;
    private float fireAngle1;
    private float bulletSpeed1;
    private Rigidbody2D rb;
    private GameObject player;
    private GameObject localBossHelperLaser;       // the laser that this object will create
    private GameObject localBullet;

    public GameObject bullet;


    void Start ()
    {
        phase = 0;
        yVelocity0 = -1;
        yVelocity1 = 4;
        startTime = Time.time;
        nextFire = 0;
        fireRate1 = 0.1f;
        //bulletSpeed = bullet.GetComponent<BossHelperBullet>().speed;
        bulletSpeed1 = 2;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, yVelocity0);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (phase == 0)
        {
            if (Time.time - startTime >= 1)
            {
                rb.velocity = new Vector2(0, -yVelocity1);
                phase = 1;
            }
        }
        else if (phase == 1)
        {
            Move1();
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate1;
                fireAngle1 = Random.Range(-30f, 30f);        // random bullet angle between -30 and 30 degrees
                localBullet = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, fireAngle1));
                localBullet.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(fireAngle1*Mathf.PI/180), Mathf.Sin(fireAngle1*Mathf.PI/180)) * bulletSpeed1;
            }
        }
	}

    void Move1()
    {
        if(rb.position.y <= bottomBoundary)
            rb.velocity = new Vector2(0, yVelocity1);
        else if(rb.position.y >= topBoundary)
            rb.velocity = new Vector2(0, -yVelocity1);
    }
}
