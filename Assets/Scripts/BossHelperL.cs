using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHelperL : BossHelper
{
    void Awake()
    {
        velocity = -1;
        nextFire = 0;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, velocity);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (phase == 0)
        {
            if (Time.time >= startTime1)
            {
                velocity = 4;
                rb.velocity = new Vector2(0, -velocity);
                phase = 1;
                fireRate = 0.1f;
                bulletSpeed = 2;
            }
        }
        else if (phase == 1)
        {
            MoveVerticallyBetweenBoundaries();

            if (Time.time > nextFire)
            {
                FireBullet(-30, 30);
            }
            if (Time.time >= startTime1t)
            {
                phase = 1.5f;

                // moves the object to the top left corner in the amount of time specified to transition between phase 1 and phase 2.
                MoveVerticallyToPosition(topBoundary, startTime2 - startTime1t);
            }
        }
        else if (phase == 1.5)
        {
            if (Time.time >= startTime2)
            {
                phase = 2;
                velocity = 2;
                // creates a laser and sets it to the proper position.
                localBossHelperLaser = Instantiate(bossHelperLaser3, transform.position, transform.rotation * Quaternion.Euler(0, 0, 90));
                localBossHelperLaser.transform.position += new Vector3(localBossHelperLaser.GetComponent<Renderer>().bounds.size.x / 2, 0, 0);
                localBossHelperLaser.transform.parent = transform;
            }
        }
        else if (phase == 2)
        {
            MoveVerticallyBetweenBoundaries();

            if (Time.time > startTime2t)
            {
                MoveVerticallyToPosition(bottomBoundary, startTime3 - startTime2t);
                Destroy(localBossHelperLaser);
                phase = 2.5f;
            }
        }

        else if (phase == 2.5)
        {
            if (Time.time > startTime3)
            {
                localBossHelperLaser = Instantiate(bossHelperLaser3, transform.position, transform.rotation * Quaternion.Euler(0, 0, 90));
                localBossHelperLaser.transform.position += new Vector3(localBossHelperLaser.GetComponent<Renderer>().bounds.size.x / 2, 0, 0);
                localBossHelperLaser.transform.parent = transform;
                rb.velocity = new Vector2(0, 0);

                subTransitionTime1 = Time.time + 2.7f;
                subTransitionTime2 = subTransitionTime1 + 2.1f;
                subTransitionTime3 = subTransitionTime2 + 2f;
                subTransitionTime4 = subTransitionTime3 + 2;

                bulletSpeed = 1;
                fireRate = 0.25f;

                phase = 3;
            }
        }
        else if(phase == 3)
        {
            MovePhase3();
        }
    }

    void MovePhase3()
    {
        // does not move
        if (subphase == 0)
        {
            if (Time.time > subTransitionTime1)
            {
                MoveVerticallyToPosition(topBoundary, subTransitionTime2 - subTransitionTime1);
                subphase = 1;
            }
        }

        // moves to top of the screen
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

        // does not move
        else if (subphase == 2)
        {
            if (Time.time > subTransitionTime3)
            {
                MoveVerticallyToPosition(bottomBoundary, subTransitionTime4 - subTransitionTime3);
                subphase = 3;
            }
        }

        // moves to bottom of the screen while firing bullets
        else if (subphase == 3)
        {
            FireBullet(-30, 30);

            if (Time.time > subTransitionTime4)
            {
                rb.velocity = new Vector2(0, 0);
                subphase = 0;

                // turns back on the laser for the next part of the attack pattern
                localBossHelperLaser.GetComponent<Renderer>().enabled = true;
                localBossHelperLaser.GetComponent<BoxCollider2D>().enabled = true;

                // set new subTransitionTimes
                subTransitionTime1 = Time.time + 2.7f;
                subTransitionTime2 = subTransitionTime1 + 2.1f;
                subTransitionTime3 = subTransitionTime2 + 2f;
                subTransitionTime4 = subTransitionTime3 + 2;
            }
        }
    }
}
