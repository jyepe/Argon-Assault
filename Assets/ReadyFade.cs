using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadyFade : MonoBehaviour {

    [SerializeField] private float durationOfFadeOut = 5f;
    [SerializeField] private float durationOfFadeIn = 5f;
    private String[] startStrings = new String[] { "Ready", "Set", "Go" };
    private Text ready;
    private int count;

	// Use this for initialization
	void Start () {
        ready = GetComponent<Text>();
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
            return;
        }
    }

    // Update is called once per frame
    void Update () {
       
	}
}
