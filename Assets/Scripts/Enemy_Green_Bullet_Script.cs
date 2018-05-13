using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Green_Bullet_Script : MonoBehaviour
{
    private int vertical_speed;
    private Rigidbody2D rb;
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
        rb.velocity = new Vector3(Mathf.Sin((Time.time - startTime) * 2), -1 * vertical_speed);
    }

    // checks if the the bullet left the boundary of our game (which I decided to be slightly larger than the part the camera sees)
    bool ExitBoundary()
    {
        if (rb.position.x < -4 || rb.position.x > 4 || rb.position.y < -1.5 || rb.position.y > 9.5)
            return true;
        else
            return false;
    }
}
