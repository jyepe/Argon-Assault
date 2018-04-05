using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {

    [SerializeField] private int pointsPerHit;
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

    public void addToScore()
    {
        scoreToAdd += pointsPerHit;
        score.text = scoreToAdd.ToString();
    }
}
