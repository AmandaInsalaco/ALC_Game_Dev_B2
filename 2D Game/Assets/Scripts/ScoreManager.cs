﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour {

    public static int Score;

    Text ScoreText;

	//Use this for initialzation

	void Start()
	{
        ScoreText = GetComponent<Text>();
        Score = 0;
	}

	//update is called once per frame

	void Update()
	{
	    if (Score < 0)
        {
            Score = 0;

        }	

        ScoreText.text = " " + Score;
	}

    //will add points o score
    public static void AddPoints (int pointsToAdd) 
    {
        Score += pointsToAdd;
    }

    //public static void Reset ()
    //{
    //    Score = 0;
    //}
}
