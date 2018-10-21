using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox_Script : MonoBehaviour
{
    private int lives;          // we put the number of lives the player has left in the hitbox script.
    private bool isInvincible;  // this stores if the player is invincible (when respawning after dying)
    private float timeOfLastDeath;
    private float invincibilityTime = 3;  // stays invincible for 3 seconds after dying

    private GameObject player;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        // This makes the hitbox location at the center of the player.
        transform.position = player.transform.position - new Vector3(0.017f, 0.009f, 0);

        // the hitbox will move with the player character.
        transform.SetParent(player.transform);

        lives = 3;
    }
	
	// Update is called once per frame
	void Update ()
    {
        // The hitbox is displayed only if shift is held down.
        if (Input.GetKey(KeyCode.LeftShift))
            this.gameObject.GetComponent<Renderer>().enabled = true;
        else
            this.gameObject.GetComponent<Renderer>().enabled = false;

        if (isInvincible == true)
        {
            // if it's been more than 3 seconds since the player respawned, it is no longer invincible
            if (Time.time - timeOfLastDeath > invincibilityTime)
            {
                this.gameObject.GetComponent<CircleCollider2D>().enabled = true;
                isInvincible = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // resolves collision with an enemy or an enemy bullet
        if (other.tag == "Enemy" || other.tag == "Enemy_Bullet" || other.tag == "EnemyLaser")
        {
            timeOfLastDeath = Time.time;

            if(other.tag == "Enemy_Bullet")
                Destroy(other.gameObject);

            if (lives > 0)
                Respawn();
            else
                Destroy(player.gameObject);
        }
    }

    void Respawn()
    {
        player.transform.position = new Vector3(0, 0, 0);
        lives--;
        isInvincible = true;
        this.gameObject.GetComponent<CircleCollider2D>().enabled = false;   // disable the collider of the hitbox temporarily
    }
}
