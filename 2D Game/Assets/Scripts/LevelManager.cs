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

    public IEnumerable RespawnPlayerCo(){
        //generate death particle
        //first part is game object we want to create
        //next spot is where we want it to be created
        //third spot is transformation and rotation
        Instantiate(deathParticle, PC.transform.position, PC.transform.rotation);
        //Hide Player
        PC.enabled = false;
        PC.GetComponent<Renderer>().enabled = false;
        //gravity Reset
        gravityStore = PC.GetComponent<Rigidbody2D>().gravityScale;
        PC.GetComponent<Rigidbody2D>().gravityScale = 0f;
        PC.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        //point penalty
        ScoreManager.AddPoints(-pointPenaltyOnDeath);
        //debug message
        Debug.Log("Player Respawn");
        //respawn delay
        yield return new WaitForSeconds(respawnDely);
        //Gravity Restore
        PC.GetComponent<Rigidbody2D>().gravityScale = gravityStore;
        //match Players transform  positions
        PC.transform.position = currentCheckPoint.transform.position;
        //Show Player

    }
}
