using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

    public LevelManager LevelManager;

    // Use this for initialization
	void Start () {
        LevelManager = FindObjectOfType<LevelManager>();
	}
	
    //kills player when passes through collider
    //then respawns using levelManager
	void OnTriggerEnter2D(Collider2D other)
	{
        if(other.name == "PC"){
            LevelManager.RespawnPlayer();
            Debug.Log("PC touches Enemy");
        }
	}
}