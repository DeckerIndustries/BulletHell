using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHelperR : BossHelper
{
    float waitTimePhase2;

    void Start()
    {
        startTime0 = Time.time;
        startTime1 = startTime0 + 1;
        startTime1t = startTime1 + 2;
        startTime2 = startTime1t + 2;
        startTime3 = startTime2 + 20;

        velocity = 1;
        fireRate = 0.1f;
        nextFire = 0;
        bulletSpeed = 2;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, velocity);

        waitTimePhase2 = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (phase == 0)
        {
            if (Time.time >= startTime1)
            {
                velocity = 4;
                rb.velocity = new Vector2(0, velocity);
                phase = 1;
            }
        }
        else if (phase == 1)
        {
            MoveVerticallyBetweenBoundaries();
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                fireAngle = Random.Range(150f, 210f);        // random bullet angle between -150 and 210 degrees
                localBullet = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, fireAngle));
                localBullet.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(fireAngle * Mathf.PI / 180), Mathf.Sin(fireAngle * Mathf.PI / 180)) * bulletSpeed;
            }
            if(Time.time >= startTime1t)
            {
                phase = 1.5f;
                MoveVerticallyToPosition(topBoundary, startTime2 - startTime1t);
            }
        }
        else if(phase == 1.5)
        {
            if (Time.time >= startTime2)
            {
                phase = 2;

                // makes this object shoot a laser (and positions it correctly)
                localBossHelperLaser = Instantiate(bossHelperLaser3, transform.position, transform.rotation * Quaternion.Euler(0, 0, 90));
                localBossHelperLaser.transform.position -= new Vector3(localBossHelperLaser.GetComponent<Renderer>().bounds.size.x / 2, 0, 0);
                localBossHelperLaser.transform.parent = transform;  // this makes the laser move with this object
                velocity = 2;
                rb.velocity = new Vector2(0, 0);
            }
        }
        else if(phase == 2)
        {
            if(Time.time >= startTime2 + waitTimePhase2)
            {
                // if the object isn't moving yet, we start moving it.
                if (rb.velocity.y == 0)
                    rb.velocity = new Vector2(0, velocity);

                MoveVerticallyBetweenBoundaries();
            }
            if(Time.time >= startTime3)
            {

            }
        }

    }
}
