using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {
    
    private Text score;
    private int scoreToAdd = 0;

	// Use this for initialization
	void Start () {
        score = GetComponent<Text>();
        score.text = scoreToAdd.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void addToScore(int points)
    {
        scoreToAdd += points;
        score.text = scoreToAdd.ToString();
    }
}
