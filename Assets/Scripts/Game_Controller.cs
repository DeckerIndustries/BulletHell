using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controller : MonoBehaviour
{
    // this lets the game know what phase we are in.  Before the midboss, at the midboss, after the midboss, or at the boss.
    enum Phase
    {
        STAGE_A,
        MIDBOSS,
        STAGE_B,
        BOSS
    };

    public GameObject enemy_green;
    public GameObject enemy_blue;
    public GameObject bossHelper;

    private float spawn_time_1;
    private Vector2 spawn_position_1;
    private int num_enemies_1;
    private float time_between_spawns_1;

    private float spawn_time_2;
    private Vector2 spawn_position_2;
    private int num_enemies_2;
    private float time_between_spawns_2;

    private float spawn_time_3;
    private Vector2 spawn_position_3;
    private int num_enemies_3;
    private float time_between_spawns_3;

    Phase phase;
    int transitionTime1;    // at this time, we transition to the second phase.

    // Use this for initialization
    void Start ()
    {
        phase = Phase.STAGE_A;

        // spawn 2 seconds after starting
        spawn_time_1 = 2;
        spawn_position_1 = new Vector2(-3.5f, 8);
        num_enemies_1 = 30;     // this is how many enemies will be spawned in this location.
        time_between_spawns_1 = 0.5f;

        spawn_time_2 = 3;
        spawn_position_2 = new Vector2(3.5f, 8.5f);
        num_enemies_2 = 10;
        time_between_spawns_2 = 0.5f;

        spawn_time_3 = 3.5f;
        spawn_position_3 = new Vector2(-3.5f, 8.5f);
        num_enemies_3 = 10;
        time_between_spawns_3 = 0.5f;

        transitionTime1 = 3;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (phase == Phase.STAGE_A)
        {
            
            if (Time.time > spawn_time_1 && num_enemies_1 > 0)
            {
                Instantiate(enemy_green, spawn_position_1, Quaternion.identity);
                spawn_time_1 += time_between_spawns_1;   // enemies will be spawned one after another with a 0.5 second delay in between spawns.
                num_enemies_1--;
            }

            if (Time.time > spawn_time_2 && num_enemies_2 > 0)
            {
                Instantiate(enemy_blue, spawn_position_2, Quaternion.identity);
                spawn_time_2 += time_between_spawns_2;
                num_enemies_2--;
            }

            if (Time.time > spawn_time_3 && num_enemies_3 > 0)
            {
                Instantiate(enemy_blue, spawn_position_3, Quaternion.identity);
                spawn_time_3 += time_between_spawns_3;
                num_enemies_3--;
            }

            if(Time.time > transitionTime1)
            {
                GameObject[] gameObjects1 = GameObject.FindGameObjectsWithTag("Enemy");
                for (int i = 0; i < gameObjects1.Length; i++)
                    Destroy(gameObjects1[i]);

                GameObject[] gameObjects2 = GameObject.FindGameObjectsWithTag("Enemy_Bullet");
                for (int i = 0; i < gameObjects2.Length; i++)
                    Destroy(gameObjects2[i]);

                Instantiate(bossHelper, new Vector2(-3.5f, -1), Quaternion.Euler(0, 0, 90));
                phase = Phase.MIDBOSS;
            }
        }
        
        else if(phase == Phase.MIDBOSS)
        {

        }
    }

}
