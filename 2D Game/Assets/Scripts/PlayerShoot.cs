using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public Transform firePoint;
    public GameObject Projectile;
	
    void Start()
    {
        //Load Projectile from Resource/Prefabs Folder
        //Projectile = GameObject.Find("Projectile");
        Projectile = Resources.Load("Prefabs/Projectile") as GameObject;
    }

	// Update is called once per frame
    // the projectile inherients the firepoints position and orientation
    //.S could be .RightControl
	void Update () {
        if (Input.GetKeyDown(KeyCode.S))
            Instantiate(Projectile, firePoint.position, firePoint.rotation);
	}
}
