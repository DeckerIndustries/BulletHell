using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHelperD : MonoBehaviour
{
    private int phase;
    private float xVelocity;
    private float startTime;                    // time when object was created
    private Rigidbody2D rb;
    private GameObject player;
    private GameObject localBossHelperLaser;    // the laser that this object will create

    public GameObject bossHelperLaser1;

    void Start ()
    {
        phase = 0;
        xVelocity = 1;
        startTime = Time.time;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(xVelocity, 0);
        
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
	// Update is called once per frame
	void FixedUpdate ()
    {
        // the unit moves slowly onto the screen initially. After a certain amount of time, it goes into phase 1.
        if (phase == 0)
        {
            if (Time.time - startTime >= 1)
            {
                // makes this object shoot a laser.
                localBossHelperLaser = Instantiate(bossHelperLaser1, transform.position, transform.rotation * Quaternion.Euler(0, 0, 90));
                localBossHelperLaser.transform.position += new Vector3(0, localBossHelperLaser.GetComponent<Renderer>().bounds.size.y / 2, 0);
                localBossHelperLaser.transform.parent = transform;

                // transition to the next phase
                phase = 1;
            }
        }
        else if (phase == 1)
            Move1();
	}

    // moves parallel to the player when the player moves right.  But stays still when the player moves left.  This means the player's left movements will be limited.
    void Move1()
    {
        if (player.transform.position.x <= transform.position.x)
            transform.position = new Vector2(-2.83f, -1);
        if (player.GetComponent<Rigidbody2D>().velocity.x > 0)
            xVelocity = player.GetComponent<Rigidbody2D>().velocity.x;
        else
            xVelocity = 0;

        rb.velocity = new Vector2(xVelocity, 0);
    }
}
