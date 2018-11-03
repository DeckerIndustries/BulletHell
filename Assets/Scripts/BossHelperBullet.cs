using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHelperBullet : Bullet
{

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (ExitBoundary() == true)
            Destroy(gameObject);
	}
}
