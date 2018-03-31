using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Green_Bullet_Script : MonoBehaviour
{

    private int vertical_speed;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   // gets the rigidbody of this bullet.  We use this to set the bullet's position and velocity.
        vertical_speed = 1;
    }

    // Update is called once per frame
    void Update ()
    {
        rb.velocity = new Vector3(2*Mathf.Sin(Time.time * 2), -1 * vertical_speed);
    }

    // This function (given to us by Unity!) lets us decide what to do when the object leaves the camera view.
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
