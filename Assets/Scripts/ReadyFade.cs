using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Utility;

public class ReadyFade : MonoBehaviour {

    [SerializeField] private float durationOfFadeOut = 5f;
    [SerializeField] private float durationOfFadeIn = 5f;
    private String[] startStrings = new String[] { "Ready", "Set", "Go!!" };
    private Text ready;
    private int count;
    private Shooting shoot;
    private WaypointProgressTracker waypoint;

	// Use this for initialization
	void Start () {
        ready = GetComponent<Text>();
        shoot = FindObjectOfType<Shooting>();
        waypoint = FindObjectOfType<WaypointProgressTracker>();
        count = 0;
        changeText();
    }

    private void startCrossFade()
    {
        ready.CrossFadeAlpha(0f, durationOfFadeOut, true);
        Invoke("changeText", durationOfFadeOut);
    }

    private void changeText()
    {
        try
        {
            ready.text = startStrings[count];
            count++;
            ready.CrossFadeAlpha(255f, durationOfFadeIn, true);
            startCrossFade();
        }
        catch (IndexOutOfRangeException ex)
        {
            shoot.startShooting();
            waypoint.setCameraSpeed(1f);
        }
    }

    // Update is called once per frame
    void Update () {
       
	}
}
