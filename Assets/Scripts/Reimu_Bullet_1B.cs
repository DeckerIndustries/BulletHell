using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reimu_Bullet_1B : Bullet
{
    private float x_velocity;
    private float y_velocity;

    // Use this for initialization
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        // if the bullet is spawned to the left of the player, it will move in an arc to the left.  Otherwise, it will move in an arc moving to the right.
        if (player.transform.position.x < transform.position.x)
            x_velocity = 1;
        else
            x_velocity = -1;
        y_velocity = 1;         // the initial y velocity is 1
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(x_velocity, y_velocity);
    }

    // Update is called once per frame
    void Update ()
    {
        if (ExitBoundary() == true)
            Destroy(gameObject);
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + 1);
    }
}
