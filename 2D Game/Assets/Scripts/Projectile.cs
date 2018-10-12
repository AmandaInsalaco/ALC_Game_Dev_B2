using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float Speed;
    public Rigidbody2D PC;
    public GameObject EnemyDeath;
    public GameObject ProjectileParticle;
    public int PointsForKill;

    // Use this for initialization
	void Start () {
        //shoots in the direction the PC is facing
        //do not need braces if you are only using one line
        if (PC.transform.localScale.x < 0)
            Speed = -Speed;
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(Speed, GetComponent<Rigidbody2D>().velocity.y);
        //PC = FindObjectOfType<RigidBody2D>();

	}

    void OnTriggerEnter2D(Collider2D other)
    {
        //kills enemy when projectile hits enemy
        //adds points
        if(other.tag == "Enemy"){
            Instantiate(EnemyDeath, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            ScoreManager.AddPoints(PointsForKill);
            Debug.Log("Projectile Hit");
        }
        //the projectile tells player that we hit the enemy
        //is instantiated right where the projectile hits
        //destroys projectile
        //When we destory a game object, it no longer exsists, the collider, and script is gone too.
        Instantiate(ProjectileParticle, transform.position, transform.rotation);
        Destroy(gameObject);
	}
}
