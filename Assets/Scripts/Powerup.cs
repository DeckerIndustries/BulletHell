using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    private float verticalSpeed;
    private Rigidbody2D rb;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        verticalSpeed = -1.5f;

        rb.velocity = new Vector2(0, verticalSpeed);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (ExitBoundary() == true)
            Destroy(gameObject);
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
