using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marissa_Bullet_1 : MonoBehaviour
{
    private float speed;
    private Rigidbody2D rb;

	// Use this for initialization
	void Start ()
    {
        speed = 10;
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

    // checks if the the bullet left the boundary of our game (which I decided to be slightly larger than the part the camera sees)
    bool ExitBoundary()
    {
        if (rb.position.x < -4 || rb.position.x > 4 || rb.position.y < -1.5 || rb.position.y > 9.5)
            return true;
        else
            return false;
    }

}
