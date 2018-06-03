using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marissa_Bullet_2 : Bullet
{

    private float speed;
    private float x_velocity;
    private float y_velocity;

    // Use this for initialization
    void Start()
    {
        speed = 20;
        rb = GetComponent<Rigidbody2D>();

        // Basically, in this part, I set the bullet's velocity based on its rotation.
        x_velocity = -Mathf.Sin(transform.localEulerAngles.z * Mathf.PI / 180);
        y_velocity = Mathf.Cos(transform.localEulerAngles.z * Mathf.PI / 180);
        rb.velocity = new Vector2(x_velocity, y_velocity) * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (ExitBoundary() == true)
            Destroy(gameObject);
    }
}
