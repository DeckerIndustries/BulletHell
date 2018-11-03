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
    protected float startTime3;

    protected float phase = 0;
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
        
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    protected void MoveHorizontallyBetweenBoundaries()
    {
        if (rb.position.x <= leftBoundary)
            rb.velocity = new Vector2(velocity, 0);
        else if (rb.position.x >= rightBoundary)
            rb.velocity = new Vector2(-velocity, 0);
    }

    protected void MoveVerticallyBetweenBoundaries()
    {
        if (rb.position.y <= bottomBoundary)
            rb.velocity = new Vector2(0, velocity);
        else if (rb.position.y >= topBoundary)
            rb.velocity = new Vector2(0, -velocity);
    }

    // moves the object to the specified position in the specified amount of time
    protected void MoveHorizontallyToPosition(float pos, float time)
    {
        velocity = (pos - rb.position.x) / time;
        rb.velocity = new Vector2(velocity, 0);
    }

    // moves the object to the specified position in the specified amount of time
    protected void MoveVerticallyToPosition(float pos, float time)
    {
        velocity = (pos - rb.position.y) / time;
        rb.velocity = new Vector2(0, velocity);
    }
}
