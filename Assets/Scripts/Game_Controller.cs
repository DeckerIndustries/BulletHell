using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controller : MonoBehaviour
{
    public GameObject enemy_green;
    public GameObject enemy_blue;

    private float spawn_time_1;
    private Vector2 spawn_position_1;
    private int flag_1;
    private float time_between_spawns_1;

    private float spawn_time_2;
    private Vector2 spawn_position_2;
    private int flag_2;
    private float time_between_spawns_2;

    private float spawn_time_3;
    private Vector2 spawn_position_3;
    private int flag_3;
    private float time_between_spawns_3;

    // Use this for initialization
    void Start ()
    {
        // spawn 2 seconds after starting
        spawn_time_1 = 2;
        spawn_position_1 = new Vector2(-3.5f, 8);
        flag_1 = 30;     // this is how many enemies will be spawned in this location.
        time_between_spawns_1 = 0.5f;

        spawn_time_2 = 3;
        spawn_position_2 = new Vector2(3.5f, 8.5f);
        flag_2 = 10;
        time_between_spawns_2 = 0.5f;

        spawn_time_3 = 3.5f;
        spawn_position_3 = new Vector2(-3.5f, 8.5f);
        flag_3 = 10;
        time_between_spawns_3 = 0.5f;
    }
	
	// Update is called once per frame
	void Update ()
    {
		/*if(Time.time > spawn_time_1 && flag_1 > 0)
        {
            Instantiate(enemy_green, spawn_position_1, Quaternion.identity);
            spawn_time_1 += time_between_spawns_1;   // enemies will be spawned one after another with a 0.5 second delay in between spawns.
            flag_1--;
        }*/

        if (Time.time > spawn_time_2 && flag_2 > 0)
        {
            Instantiate(enemy_blue, spawn_position_2, Quaternion.identity);
            spawn_time_2 += time_between_spawns_2;
            flag_2--;
        }

        if (Time.time > spawn_time_3 && flag_3 > 0)
        {
            Instantiate(enemy_blue, spawn_position_3, Quaternion.identity);
            spawn_time_3 += time_between_spawns_3;
            flag_3--;
        }
    }

}
