using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHelperU : BossHelper
{
    void Start()
    {
        startTime0 = Time.time;
        startTime1 = startTime0 + 1;
        startTime1t = startTime1 + 2;
        startTime2 = startTime1t + 2;

        velocity = -2;
        nextFire = 0;
        rb = GetComponent<Rigidbody2D>();
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
                nextFire = Time.time + fireRate;
                fireAngle = Random.Range(190, 350);        // random bullet angle between -150 and 210 degrees
                localBullet = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, fireAngle));
                localBullet.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(fireAngle * Mathf.PI / 180), Mathf.Sin(fireAngle * Mathf.PI / 180)) * bulletSpeed;
            }
        }
    }

}
