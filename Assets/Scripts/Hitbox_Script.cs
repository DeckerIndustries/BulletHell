using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox_Script : MonoBehaviour
{
    private GameObject player;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update ()
    {
        // display the hitbox if shift is held down, but not otherwise.
        //if (Input.GetKey(KeyCode.LeftShift))
        //    transform.position = player.transform.position - new Vector3(0.017f, 0.009f, 0);
        //else
        //    transform.position = new Vector3(0, -2, 0);         // if the player is not holding shift, I don't want the hitbox to show up, so I just move it offscreen

        if (Input.GetKey(KeyCode.LeftShift))
            this.gameObject.GetComponent<Renderer>().enabled = true;
        else
            this.gameObject.GetComponent<Renderer>().enabled = false;

        transform.position = player.transform.position - new Vector3(0.017f, 0.009f, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" || other.tag == "Enemy_Bullet")
        {
            Destroy(other.gameObject);
            Destroy(player.gameObject);
            Destroy(gameObject);
            
        }
    }
}
