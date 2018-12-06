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
    public GameObject bossHelperD;
    public GameObject bossHelperU;
    public GameObject bossHelperL;
    public GameObject bossHelperR;

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

    private Phase phase;
    private int subphase;               // This is currently used so we know which midboss / boss attack we are on.
    private float transitionTimeA;    // at this time, we transition from phase A to the next phase..
    private float subTransitionTime1;
    private float phaseStartTime;       // the time when the current phase has started

    // Use this for initialization
    void Start ()
    {
        phase = Phase.STAGE_A;
        subphase = 0;

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

        subphase = 1;
        transitionTimeA = 20;        // amount of time spent in phase A before transitioning to the next phase.
        subTransitionTime1 = 5;
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

            if(Time.time > transitionTimeA)
            {
                GameObject[] gameObjects1 = GameObject.FindGameObjectsWithTag("Enemy");
                for (int i = 0; i < gameObjects1.Length; i++)
                    Destroy(gameObjects1[i]);

                GameObject[] gameObjects2 = GameObject.FindGameObjectsWithTag("Enemy_Bullet");
                for (int i = 0; i < gameObjects2.Length; i++)
                    Destroy(gameObjects2[i]);

                Instantiate(bossHelperD, new Vector2(-3.83f, -1), Quaternion.Euler(0, 0, 90));
                Instantiate(bossHelperU, new Vector2(3.83f, 9), Quaternion.Euler(0, 0, -90));
                Instantiate(bossHelperL, new Vector2(-3.33f, 9.5f), Quaternion.identity);
                Instantiate(bossHelperR, new Vector2(3.33f, -1.5f), Quaternion.Euler(0, 0, 180));

                phaseStartTime = Time.time;
                phase = Phase.MIDBOSS;
            }
        }
        
        else if(phase == Phase.MIDBOSS)
        {
            //if(subphase == 1)
                //if (Time.time - phaseStartTime >= subTransitionTime1)
                    //subphase = 2;

            //else if(subphase == 2)
                
        }
    }

}
