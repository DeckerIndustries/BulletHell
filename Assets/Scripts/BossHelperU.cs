using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHelperU : BossHelper
{
    // called before the entire game starts
    void Awake()
    {
        velocity = -2;
        rb = GetComponent<Rigidbody2D>();
        nextFire = 0;
        rb.velocity = new Vector2(velocity, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (phase == 0)
        {
            if (Time.time >= startTime1)
            {
                localBossHelperLaser = Instantiate(bossHelperLaser2, transform.position, transform.rotation * Quaternion.Euler(0, 0, 90));
                localBossHelperLaser.transform.position -= new Vector3(0, localBossHelperLaser.GetComponent<Renderer>().bounds.size.y / 2, 0);
                localBossHelperLaser.transform.parent = transform;

                rb.velocity = new Vector2(0, 0);

                phase = 1;
            }
        }
        else if (phase == 1)
        {
            // this guy doesn't move in phase 1
            if (Time.time >= startTime1t)
            {
                Destroy(localBossHelperLaser);
                MoveHorizontallyToPosition((leftBoundary + rightBoundary) / 2, startTime2 - startTime1t);
                phase = 1.5f;
            }
        }

        // transition phase from phase 1 to phase 2
        else if (phase == 1.5)
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
        else if (phase == 2)
        {
            if (Time.time > nextFire)
            {
                FireBullet(190, 350);
            }

            if (Time.time > startTime2t)
            {
                MoveHorizontallyToPosition(leftBoundary, startTime3 - startTime2t);
                phase = 2.5f;
            }
        }
        else if (phase == 2.5)
        {
            if (Time.time > startTime3)
            {
                rb.velocity = new Vector2(0, 0);
                localBossHelperLaser = Instantiate(bossHelperLaser3, transform.position, transform.rotation * Quaternion.Euler(0, 0, 90));
                localBossHelperLaser.transform.localScale += new Vector3(0, 2, 0);
                localBossHelperLaser.transform.position -= new Vector3(0, localBossHelperLaser.GetComponent<Renderer>().bounds.size.y / 2, 0);
                localBossHelperLaser.transform.parent = transform;  // this makes the laser move with this object

                // set all transition times for phase 3
                subTransitionTime1 = Time.time + 3.4f;
                subTransitionTime2 = subTransitionTime1 + 1.4f;
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

    void MovePhase3()
    {
        if (subphase == 0)
        {
            if (Time.time > subTransitionTime1)
            {
                MoveHorizontallyToPosition(rightBoundary, subTransitionTime2 - subTransitionTime1);
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
                MoveHorizontallyToPosition(leftBoundary, subTransitionTime4 - subTransitionTime3);
                subphase = 3;
            }
        }
        else if (subphase == 3)
        {
            FireBullet(240, 300);

            if (Time.time > subTransitionTime4)
            {
                rb.velocity = new Vector2(0, 0);
                subphase = 0;

                // turns back on the laser for the next part of the attack pattern
                localBossHelperLaser.GetComponent<Renderer>().enabled = true;
                localBossHelperLaser.GetComponent<BoxCollider2D>().enabled = true;

                // set new subTransitionTimes
                subTransitionTime1 = Time.time + 3.4f;
                subTransitionTime2 = subTransitionTime1 + 1.4f;
                subTransitionTime3 = subTransitionTime2 + 2f;
                subTransitionTime4 = subTransitionTime3 + 2;
            }
        }
    }
}

