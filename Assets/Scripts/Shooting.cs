using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    [SerializeField] ParticleSystem leftBullets;
    [SerializeField] ParticleSystem rightBullets;
    AudioSource soundPlayer;

    // Use this for initialization
    void Start () {
        soundPlayer = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

        if (!Input.GetKey(KeyCode.Space))
        {
            leftBullets.Play();
            rightBullets.Play();
            soundPlayer.Stop();
        }
        else
        {
            if (!soundPlayer.isPlaying)
            {
                soundPlayer.Play();
            }
        }
	}
}
