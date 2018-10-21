using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHelperU : MonoBehaviour
{
    private float leftBoundary = -3.08f;
    private float rightBoundary = 3.08f;

    private int phase;
    private float xVelocity0;   // x velocity for phase 0
    private float xVelocity1;   // x velocity for phase 1
    private float startTime;
    private float nextFire;
    private float fireRate1;
    private float fireAngle1;
    private float bulletSpeed;
    private Rigidbody2D rb;
    private GameObject player;
    private GameObject localBossHelperLaser;       // the laser that this object will create
    private GameObject localBullet;

    public GameObject bullet;
    public GameObject bossHelperLaser1;
    public GameObject bossHelperLaser2;


    void Start()
    {
        phase = 0;
        xVelocity0 = -1;
        xVelocity1 = 4;
        startTime = Time.time;
        nextFire = 0;
        fireRate1 = 0.1f;
        //bulletSpeed = bullet.GetComponent<BossHelperBullet>().speed;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(xVelocity0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (phase == 0)
        {
            if (Time.time - startTime >= 1)
            {
                //rb.velocity = new Vector2(-xVelocity1, 0);
                localBossHelperLaser = Instantiate(bossHelperLaser2, transform.position, transform.rotation * Quaternion.Euler(0, 0, 90));
                localBossHelperLaser.transform.position -= new Vector3(0, localBossHelperLaser.GetComponent<Renderer>().bounds.size.y / 2, 0);
                localBossHelperLaser.transform.parent = transform;

                rb.velocity = new Vector2(0, 0);

                phase = 1;
            }
        }
        else if (phase == 1)
        {
            Move1();
            /*
            if (Time.time > nextFire)
            {
              nextFire = Time.time + fireRate1;
               fireAngle1 = Random.Range(240f, 300f);        // random bullet angle between 60 and 120 degrees
               localBullet = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, fireAngle1));
               localBullet.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(fireAngle1 * Mathf.PI / 180), Mathf.Sin(fireAngle1 * Mathf.PI / 180)) * bulletSpeed;
            }
            */
        }
    }

    void Move1()
    {
        // the object will just bounce back and forth across the walls.
        /*if (rb.position.x <= leftBoundary)
            rb.velocity = new Vector2(xVelocity1, 0);
        else if (rb.position.x >= rightBoundary)
            rb.velocity = new Vector2(-xVelocity1, 0);*/
    }
}
