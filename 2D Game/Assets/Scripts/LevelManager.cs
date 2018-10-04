using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckPoint;
    private Rigidbody2D PC;

    //particles
    public GameObject deathParticle;
    public GameObject respawnParticle;

    //Respawn Delay
    public float respawnDely;

    //Point Penalty on Death
    public int pointPenaltyOnDeath;

    //Store Gravity Value
    private float gravityStore;

    // Use this for initialization
	void Start () {
        PC = FindObjectOfType<Rigidbody2D>();
	}
	
    //running in the background
    public void RespawnPlayer(){
        StartCoroutine("RespawnPlayerCo");
    }

    public IEnumerator RespawnPlayerCo(){
        //generate death particle
        //instantiate is creating a game object in our world
        //first part is game object we want to create
        //next spot is where we want it to be created
        //third spot is transformation and rotation
        Instantiate(deathParticle, PC.transform.position, PC.transform.rotation);
        //Hide Player
        //use this as a smoke and mirrors effect while we move the player
        //PC.enabled = false;
        PC.GetComponent<Renderer>().enabled = false;
        //gravity Reset
        //with rigidy body there's velocity, a PC has the same 
        //velocity that it had when it dies, so we need to reset
        gravityStore = PC.GetComponent<Rigidbody2D>().gravityScale;
        PC.GetComponent<Rigidbody2D>().gravityScale = 0f;
        PC.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        //point penalty
        ScoreManager.AddPoints(-pointPenaltyOnDeath);
        //debug message
        Debug.Log("Player Respawn");
        //respawn delay
        //pause so that you don't insatntly reappear
        yield return new WaitForSeconds(respawnDely);
        //Gravity Restore
        //took away the gravity and now we are restoring it
        PC.GetComponent<Rigidbody2D>().gravityScale = gravityStore;
        //match Players transform  positions
        //puts the player at the check point
        PC.transform.position = currentCheckPoint.transform.position;
        //Show Player
        //PC.enabled = true;
        PC.GetComponent<Renderer>().enabled = true;
        Instantiate(respawnParticle, currentCheckPoint.transform.position, currentCheckPoint.transform.rotation);
    }
}
