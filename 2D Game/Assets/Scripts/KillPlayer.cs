using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

    public LevelManager levelManager;

    // Use this for initialization
	void Start () {
        levelManager = FindObjectOfType<LevelManager>();
	}
	
    //kills player when passes through collider
    //then respawns using levelManager
	void OnTriggerEnter2D(Collider2D other)
	{
        if(other.name == "PC"){
            levelManager.RespawnPlayer();
            Debug.Log("PC touches Enemy");
        }
	}
}
