using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reimu_Bullet_1 : Bullet
{
    private float speed;

	// Use this for initialization
	void Start ()
    {
        speed = 25;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);
	}

    // Update is called once per frame
    void Update ()
    {
        if (ExitBoundary() == true)
            Destroy(gameObject);
    }
}
