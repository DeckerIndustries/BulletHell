using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHelperD : BossHelper
{
    void Start ()
    {
        startTime0 = Time.time;
        startTime1 = startTime0 + 1;
        startTime1t = startTime1 + 2;
        startTime2 = startTime1t + 2;

        velocity = 1;
        nextFire = 0;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(velocity, 0);
        
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
	// Update is called once per frame
	void FixedUpdate ()
    {
        // the unit moves slowly onto the screen initially. After a certain amount of time, it goes into phase 1.
        if (phase == 0)
        {
            if (Time.time >= startTime1)
            {
                // makes this object shoot a laser.
                localBossHelperLaser = Instantiate(bossHelperLaser1, transform.position, transform.rotation * Quaternion.Euler(0, 0, 90));
                localBossHelperLaser.transform.position += new Vector3(0, localBossHelperLaser.GetComponent<Renderer>().bounds.size.y / 2, 0);
                localBossHelperLaser.transform.parent = transform;

                // transition to the next phase
                phase = 1;
            }
        }
        else if (phase == 1)
        {
            MovePhase1();
            if (Time.time > startTime1t)
            {
                Destroy(localBossHelperLaser);
                MoveHorizontallyToPosition((leftBoundary + rightBoundary) / 2, startTime2 - startTime1t);
                phase = 1.5f;
            }
        }
        else if(phase == 1.5)
        {
            if (Time.time >= startTime2)
            {
                velocity = 0;
                rb.velocity = new Vector2(velocity, 0);
                fireRate = 0.15f;     // rate of fire for phase 2
                bulletSpeed = 1;
                phase = 2;
            }
        }
        else if(phase == 2)
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                fireAngle = Random.Range(10, 170);        // random bullet angle between -150 and 210 degrees
                localBullet = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, fireAngle));
                localBullet.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(fireAngle * Mathf.PI / 180), Mathf.Sin(fireAngle * Mathf.PI / 180)) * bulletSpeed;
            }
        }
	}

    // moves parallel to the player when the player moves right.  But stays still when the player moves left.  This means the player's left movements will be limited.
    void MovePhase1()
    {
        if (player.transform.position.x <= transform.position.x)
            transform.position = new Vector2(-2.83f, -1);
        if (player.GetComponent<Rigidbody2D>().velocity.x > 0)
            velocity = player.GetComponent<Rigidbody2D>().velocity.x;
        else
            velocity = 0;

        rb.velocity = new Vector2(velocity, 0);
    }
}
