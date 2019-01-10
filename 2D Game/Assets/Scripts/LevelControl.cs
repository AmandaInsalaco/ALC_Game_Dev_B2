using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour {

    public int index;
    public string levelName;
    public GameObject Projectile;
    public Transform firePoint;

    void Start()
    {
        //Load Projectile from Resource/Prefabs Folder
        //Projectile = GameObject.Find("Projectile");
        Projectile = Resources.Load("Prefabs/Projectile") as GameObject;
    }

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Player"))
        {
            //loading level with build index
            SceneManager.LoadScene(index);

            //loading level with scene name
            SceneManager.LoadScene(levelName);
            Instantiate(Projectile, firePoint.position, firePoint.rotation);
            //Restart lvl1
            //SceneManger.LoadScene(SceneManger.GetActiveScene().buildIndex);
        }
	}
}