using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Bullet_Type
{
    Reimu_Bullet,
    Reimu_Bullet_Sp1,
    Reimu_Bullet_Sp2
}

public class Player_Bullet : MonoBehaviour
{
    public int damage;
    public Bullet_Type type;

    private Rigidbody2D rb;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
