using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class CoinPickUp : MonoBehaviour {

    public int pointsToAdd;

	void OnTriggerEnter2D(Collider2D other)
	{
        if (other.GetComponent<Rigidbody2D>()== null)
            return;

        ScoreManager.AddPoints (pointsToAdd);

        Destroy (gameObject);
	}

}
