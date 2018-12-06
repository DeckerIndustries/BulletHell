using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHelper : MonoBehaviour
{
    protected float topBoundary = 8.75f;
    protected float bottomBoundary = -0.75f;
    protected float leftBoundary = -3.08f;
    protected float rightBoundary = 3.08f;

    protected float startTime0;
    protected float startTime1;
    protected float startTime1t;
    protected float startTime2;
    protected float startTime2t;
    protected float startTime3;
    protected float startTime3t;
    protected float startTime4;
    protected float startTime4t;
    protected float startTime5;

    protected float subTransitionTime1;
    protected float subTransitionTime2;
    protected float subTransitionTime3;
    protected float subTransitionTime4;

    protected float phase = 0;
    protected float subphase = 0;
    protected float velocity;
    
    protected float nextFire;
    protected float fireRate;
    protected float fireAngle;
    protected float bulletSpeed;
    protected Rigidbody2D rb;
    protected GameObject player;
    protected GameObject localBossHelperLaser;       // stores the currently active laser
    protected GameObject localBullet;

    public GameObject bullet;
    public GameObject bossHelperLaser1;
    public GameObject bossHelperLaser2;
    public GameObject bossHelperLaser3;

    // Use this for initialization
    void Start ()
    {
        // sets how long each phase of this boss will last
        startTime0 = Time.time;
        startTime1 = startTime0 + 1;
        startTime1t = startTime1 + 10;
        startTime2 = startTime1t + 2;
        startTime2t = startTime2 + 10;
        startTime3 = startTime2t + 2;
        startTime3t = startTime3 + 10;
        startTime4 = startTime3t + 2;
        startTime4t = startTime4 + 10;
        startTime5 = startTime4t + 2;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    // bounces the object between the left and right boundaries
    protected void MoveHorizontallyBetweenBoundaries()
    {
        // if the object isn't moving yet, we start moving it.
        if (rb.velocity.x == 0)
            rb.velocity = new Vector2(velocity, 0);

        if (rb.position.x <= leftBoundary)
            rb.velocity = new Vector2(velocity, 0);
        else if (rb.position.x >= rightBoundary)
            rb.velocity = new Vector2(-velocity, 0);
    }

    // bounces the object between the top and bottom boundaries
    protected void MoveVerticallyBetweenBoundaries()
    {
        // if the object isn't moving yet, we start moving it.
        if (rb.velocity.y == 0)
            rb.velocity = new Vector2(0, velocity);

        if (rb.position.y <= bottomBoundary)
            rb.velocity = new Vector2(0, velocity);
        else if (rb.position.y >= topBoundary)
            rb.velocity = new Vector2(0, -velocity);
    }

    // moves the object to the specified position (x coordinate) in the specified amount of time
    protected void MoveHorizontallyToPosition(float pos, float time)
    {
        rb.velocity = new Vector2((pos - rb.position.x) / time, 0);
    }

    // moves the object to the specified position (y coordinate) in the specified amount of time
    protected void MoveVerticallyToPosition(float pos, float time)
    {
        rb.velocity = new Vector2(0, (pos - rb.position.y) / time);
    }

    protected void FireBullet(float lowAngle, float highAngle)
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            float fireAngle = Random.Range(lowAngle, highAngle);        // random bullet angle between lowAngle and highAngle degrees
            localBullet = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, fireAngle));
            localBullet.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(fireAngle * Mathf.PI / 180), Mathf.Sin(fireAngle * Mathf.PI / 180)) * bulletSpeed;
        }
    }
}
