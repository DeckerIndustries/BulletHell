using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHelperD : MonoBehaviour
{
    private int phase;
    private float xVelocity;
    private Rigidbody2D rb;
    private GameObject player;
    private GameObject localBossHelperLaser;       // the laser that this object will create

    public GameObject bossHelperLaser;

    // Use this for initialization
    void Start ()
    {
        phase = 0;
        xVelocity = 1;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(xVelocity, 0);

        player = GameObject.FindGameObjectWithTag("Player");

        // makes this object shoot a laser.
        localBossHelperLaser = Instantiate(bossHelperLaser, transform.position, transform.rotation * Quaternion.Euler(0, 0, 90));
        localBossHelperLaser.transform.position += new Vector3(0, localBossHelperLaser.GetComponent<Renderer>().bounds.size.y/2, 0);
        localBossHelperLaser.transform.parent = transform;
    }
    
	// Update is called once per frame
	void FixedUpdate ()
    {
        // the unit moves slowly onto the screen initially. After it gets to a certain position, it goes into phase 1.
        if (phase == 0)
        {
            if (transform.position.x >= -3)
                phase = 1;
        }
        else if (phase == 1)
            Move1();
	}

    // moves parallel to the player when the player moves right.  But stays still when the player moves left.  This means the player's left movements will be limited.
    void Move1()
    {
        if (Input.GetKey(KeyCode.RightArrow))
            xVelocity = player.GetComponent<Rigidbody2D>().velocity.x;
        else
            xVelocity = 0;

        rb.velocity = new Vector2(xVelocity, 0);
    }
}
