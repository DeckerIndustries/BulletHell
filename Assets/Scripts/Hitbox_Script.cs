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

        // The hitbox is displayed only if shift is held down.
        if (Input.GetKey(KeyCode.LeftShift))
            this.gameObject.GetComponent<Renderer>().enabled = true;
        else
            this.gameObject.GetComponent<Renderer>().enabled = false;

        // This makes the hitbox location at the center of the player.
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
