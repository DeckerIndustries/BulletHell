using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    protected float fire_rate_1;
    protected float next_fire_1;
    protected int powerupBarrier1;
    protected float fire_rate_2;
    protected float next_fire_2;
    protected int powerupBarrier2;
    protected float focussedSpeed;
    protected float nonFocussedSpeed;
    protected float xVelocity, yVelocity;
    protected float posX, posY;
    protected float xMin, xMax, yMin, yMax;
    protected float powerupLevel;
    protected Rigidbody2D rb;     // this is the player object.
    protected Animator animator;  // controlls animation

    protected void MovePlayer(float speed)
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            xVelocity = -1 * speed;
            animator.SetInteger("Direction", -1);       // this makes the game play the animation for the player moving left
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            xVelocity = speed;
            animator.SetInteger("Direction", 1);        // this makes the game play the animation for the player moving right
        }
        else
        {
            xVelocity = 0;
            animator.SetInteger("Direction", 0);        // this makes the game play the animation for the player not moving left or right
        }

        if (Input.GetKey(KeyCode.DownArrow))
            yVelocity = -1 * speed;
        else if (Input.GetKey(KeyCode.UpArrow))
            yVelocity = speed;
        else
            yVelocity = 0;

        // if the player will move off the edge of the screen, we put its location at the very edge.
        if (rb.position.x + xVelocity * Time.fixedDeltaTime < xMin)
        {
            posX = xMin;
            xVelocity = 0;
        }
        else if (rb.position.x + xVelocity * Time.fixedDeltaTime > xMax)
        {
            posX = xMax;
            xVelocity = 0;
        }
        else
            posX = rb.position.x;
        if (rb.position.y + yVelocity * Time.fixedDeltaTime < yMin)
        {
            posY = yMin;
            yVelocity = 0;
        }
        else if (rb.position.y + yVelocity * Time.fixedDeltaTime > yMax)
        {
            posY = yMax;
            yVelocity = 0;
        }
        else
            posY = rb.position.y;

        // set the player's position and velocity
        rb.position = new Vector2(posX, posY);
        rb.velocity = new Vector2(xVelocity, yVelocity);
    }
}

