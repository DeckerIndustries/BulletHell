using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reimu_Bullet_1 : MonoBehaviour
{
    private int speed;
    private Rigidbody2D rb;

	// Use this for initialization
	void Start ()
    {
        speed = 25;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);
	}

    // Update is called once per frame
    //void Update () {

    //}

    // This function (given to us by Unity!) lets us decide what to do when the object leaves the camera view.
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
