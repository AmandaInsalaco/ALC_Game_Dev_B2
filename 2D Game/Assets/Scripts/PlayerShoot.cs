using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public Transform firePoint;
    public GameObject projectile;
	
	// Update is called once per frame
    // the projectile inherients the firepoints position and orientation
    //.S could be .RightControl
	void Update () {
        if (Input.GetKeyDown(KeyCode.S))
            Instantiate(projectile,firePoint.position, firePoint.rotation);
	}
}
