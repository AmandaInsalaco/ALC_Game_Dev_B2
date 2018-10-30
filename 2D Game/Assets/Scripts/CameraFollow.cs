using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public PC_CharMove Player;
    public bool isFollowing;
    //camera position offset
    public float xoffset;
    public float yoffset;

    // Use this for initialization
	void Start () {
        Player = FindObjectOfType<PC_CharMove>();
        isFollowing = true;
	}
	
	// Update is called once per frame
    //z is mostly used for depth, to zoom in and out
	void Update () {
        if (isFollowing)
        {
            transform.position = new Vector3(Player.transform.position.x + xoffset, Player.transform.position.y + yoffset, transform.position.z);
        }
        }
}
