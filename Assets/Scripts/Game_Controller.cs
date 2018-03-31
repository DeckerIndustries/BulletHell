using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controller : MonoBehaviour
{
    public GameObject enemy_green;
    public GameObject enemy_blue;

    private float spawn_time_1;
    private int flag_1;

    private float spawn_time_2;
    private int flag_2;

    private Vector2 spawn_position_1;
    private Vector2 spawn_position_2;

    // Use this for initialization
    void Start ()
    {
        // spawn 5 seconds after starting
        spawn_time_1 = 2;
        spawn_position_1 = new Vector2(-3.5f, 8);
        flag_1 = 3;

        spawn_time_2 = 3;
        spawn_position_2 = new Vector2(3.5f, 8.5f);
        flag_2 = 1;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(Time.time > spawn_time_1 && flag_1 > 0)
        {
            Instantiate(enemy_green, spawn_position_1, Quaternion.identity);
            spawn_time_1 += 0.5f;
            flag_1--;
        }

        if (Time.time > spawn_time_2 && flag_2 > 0)
        {
            Instantiate(enemy_blue, spawn_position_2, Quaternion.identity);
            flag_2--;
        }
    }

}
