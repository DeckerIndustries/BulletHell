using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reimu_Bullet_2 : MonoBehaviour
{
    private float max_velocity;
    private Rigidbody2D rb;

	// Use this for initialization
	void Start ()
    {
        max_velocity = 7;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, max_velocity);
	}
	
	// Update is called once per frame
	void Update ()
    {
        GameObject enemy = GameObject.FindWithTag("Enemy");
        if(enemy != null)
        {
            Vector2 vector_to_an_enemy = new Vector2(enemy.transform.position.x - transform.position.x, enemy.transform.position.y - transform.position.y);
            //vector_to_an_enemy = Vector2.ClampMagnitude(vector_to_an_enemy, 0.5f);
            //print("ev");
            rb.velocity = rb.velocity + vector_to_an_enemy;
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, 10);
            //Vector3 rotation_vector = new Vector3(rb.velocity.x, rb.velocity.y, 0);
            //transform.rotation = Quaternion.LookRotation(rotation_vector);
        }
	}

    // destroys the object if it leaves the camera view
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
