using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marissa_Bullet_1 : Bullet
{
    private float speed;

	// Use this for initialization
	void Start ()
    {
        speed = 20;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);
	}
	
	// Update is called once per frame
	void Update ()
    {
        // checks if the bullet left the boundary of the game
        if (ExitBoundary() == true)
            Destroy(gameObject);
    }
}

// I was just testing something with this
/*public class Marissa_Bullet_1 : Bullet
{
    //private float speed;
    private Rigidbody2D rb;

	// Use this for initialization
	void Start ()
    {
        //speed = 10;
        rb = GetComponent<Rigidbody2D>();
        //rb.velocity = new Vector2(0, speed);
	}
	
	// Update is called once per frame
	void Update ()
    {
        //
        if (transform.localScale.y <= 20)
        {
            transform.localScale += new Vector3(0, 0.8f, 0);
            transform.position += new Vector3(0, 0.2f, 0);
        }
        // checks if the bullet left the boundary of the game
        //if (ExitBoundary() == true)
        //    Destroy(gameObject);
    }
}*/
