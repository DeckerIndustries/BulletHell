using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Green_Bullet_Script : Bullet
{
    private int vertical_speed;
    private float startTime;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   // gets the rigidbody of this bullet.  We use this to set the bullet's position and velocity.
        vertical_speed = 3;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update ()
    {
        if (ExitBoundary() == true)
            Destroy(gameObject);
        // this gives the bullets a "wavy" pattern
        rb.velocity = new Vector3(Mathf.Sin((Time.time - startTime) * 2), -1 * vertical_speed);
    }
}
