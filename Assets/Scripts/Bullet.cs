﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected Rigidbody2D rb;

    // checks if the the bullet left the boundary of our game (which I decided to be slightly larger than the part the camera sees)
    protected bool ExitBoundary()
    {
        if (rb.position.x < -3.5 || rb.position.x > 3.5 || rb.position.y < -1.25 || rb.position.y > 9.25)
            return true;
        else
            return false;
    }
}
