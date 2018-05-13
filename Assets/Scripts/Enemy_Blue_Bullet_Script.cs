using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Blue_Bullet_Script : MonoBehaviour
{
    private int speed;
    private Rigidbody2D rb;
    private GameObject player;
    private float velocity_x;
    private float velocity_y;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 3;

        player = GameObject.FindGameObjectWithTag("Player"); // this lets the bullet have information about the player.

        velocity_x = player.transform.position.x - transform.position.x;
        velocity_y = player.transform.position.y - transform.position.y;

        float scale = speed / Mathf.Sqrt(velocity_x * velocity_x + velocity_y * velocity_y);
        rb.velocity = new Vector2(velocity_x * scale, velocity_y * scale);
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
