using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHelperR : BossHelper
{
    float waitTime;

    void Awake()
    {
        velocity = 1;
        nextFire = 0;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, velocity);
        player = GameObject.FindGameObjectWithTag("Player");
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
                fireRate = 0.1f;
                bulletSpeed = 2;
                phase = 1;
            }
        }
        else if (phase == 1)
        {
            MoveVerticallyBetweenBoundaries();
            FireBullet(150, 210);
            if (Time.time >= startTime1t)
            {
                phase = 1.5f;
                MoveVerticallyToPosition(topBoundary, startTime2 - startTime1t);
            }
        }
        else if (phase == 1.5)
        {
            if (Time.time >= startTime2)
            {
                waitTime = 2;
                phase = 2;

                // makes this object shoot a laser (and positions it correctly)
                localBossHelperLaser = Instantiate(bossHelperLaser3, transform.position, transform.rotation * Quaternion.Euler(0, 0, 90));
                localBossHelperLaser.transform.position -= new Vector3(localBossHelperLaser.GetComponent<Renderer>().bounds.size.x / 2, 0, 0);
                localBossHelperLaser.transform.parent = transform;  // this makes the laser move with this object
                velocity = 2;
                rb.velocity = new Vector2(0, 0);
            }
        }
        else if (phase == 2)
        {
            // only starts moving after "waitTime" seconds
            if (Time.time - startTime2 >= waitTime)
                MoveVerticallyBetweenBoundaries();

            if (Time.time >= startTime2t)
            {
                MoveVerticallyToPosition(topBoundary, startTime3 - startTime2t);
                Destroy(localBossHelperLaser);
                phase = 2.5f;
            }
        }
        else if (phase == 2.5)
        {
            if (Time.time > startTime3)
            {
                // makes this object shoot a laser (and positions it correctly)
                localBossHelperLaser = Instantiate(bossHelperLaser3, transform.position, transform.rotation * Quaternion.Euler(0, 0, 90));
                localBossHelperLaser.transform.localScale -= new Vector3(0, 1.5f, 0);
                localBossHelperLaser.transform.position -= new Vector3(localBossHelperLaser.GetComponent<Renderer>().bounds.size.x / 2, 0, 0);
                localBossHelperLaser.transform.parent = transform;  // this makes the laser move with this object
                rb.velocity = new Vector2(0, 0);

                subTransitionTime1 = Time.time + 2;
                subTransitionTime2 = subTransitionTime1 + 2.1f;
                subTransitionTime3 = subTransitionTime2 + 2.7f;
                subTransitionTime4 = subTransitionTime3 + 2;

                bulletSpeed = 1;
                fireRate = 0.25f;

                phase = 3;
            }
        }
        else if (phase == 3)
        {
            MovePhase3();

            if(Time.time >= startTime3t)
            {
                Destroy(localBossHelperLaser);
                MoveVerticallyToPosition(bottomBoundary, startTime4 - startTime3t);
                phase = 3.5f;
                waitTime = 2;
            }
        }
        else if (phase == 3.5f)
        {
            if (Time.time >= startTime4)
            {
                localBossHelperLaser = Instantiate(bossHelperLaser3, transform.position, transform.rotation * Quaternion.Euler(0, 0, 90));
                localBossHelperLaser.transform.localScale += new Vector3(0, 7, 0);
                localBossHelperLaser.transform.position -= new Vector3(localBossHelperLaser.GetComponent<Renderer>().bounds.size.x / 2, 0, 0);
                localBossHelperLaser.transform.parent = transform;
                MoveVerticallyToPosition((topBoundary + bottomBoundary) / 2 - 1, waitTime);
                phase = 4f;
            }
        }
        else if (phase == 4)
        {
            if (Time.time - startTime4 > waitTime && rb.velocity.y != 0)
                rb.velocity = new Vector2(0, 0);

            if (Time.time > startTime4t)
            {
                Destroy(localBossHelperLaser);
                MoveVerticallyToPosition(bottomBoundary, startTime5 - startTime4t);
                phase = 4.5f;
            }
        }
        else if(phase == 4.5f)
        {
            if (Time.time >= startTime5)
            {
                velocity = 20;
                bulletSpeed = 1;
                fireRate = 0.075f;
                phase = 5;
            }
        }
        else if(phase == 5)
        {
            MoveVerticallyBetweenBoundaries();
            FireBullet(150, 210);
        }

    }

    void MovePhase3()
    {
        if (subphase == 0)
        {
            if (Time.time > subTransitionTime1)
            {
                MoveVerticallyToPosition(bottomBoundary, subTransitionTime2 - subTransitionTime1);
                subphase = 1;
            }
        }
        else if (subphase == 1)
        {
            if (Time.time > subTransitionTime2)
            {
                // turns off the laser for the next part of the attack pattern
                localBossHelperLaser.GetComponent<Renderer>().enabled = false;
                localBossHelperLaser.GetComponent<BoxCollider2D>().enabled = false;

                rb.velocity = new Vector2(0, 0);
                subphase = 2;
            }
        }
        else if (subphase == 2)
        {
            if (Time.time > subTransitionTime3)
            {
                MoveVerticallyToPosition(topBoundary, subTransitionTime4 - subTransitionTime3);
                subphase = 3;
            }
        }
        else if (subphase == 3)
        {
            FireBullet(150, 210);

            if (Time.time > subTransitionTime4)
            {
                rb.velocity = new Vector2(0, 0);
                subphase = 0;

                // turns back on the laser for the next part of the attack pattern
                localBossHelperLaser.GetComponent<Renderer>().enabled = true;
                localBossHelperLaser.GetComponent<BoxCollider2D>().enabled = true;

                // set new subTransitionTimes
                subTransitionTime1 = Time.time + 2;
                subTransitionTime2 = subTransitionTime1 + 2.1f;
                subTransitionTime3 = subTransitionTime2 + 2.7f;
                subTransitionTime4 = subTransitionTime3 + 2;
            }
        }
    }
}
