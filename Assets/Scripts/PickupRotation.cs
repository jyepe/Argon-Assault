﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupRotation : MonoBehaviour {

    [SerializeField] private Vector3 rotationSpeed;
    private AudioSource reloadClip;

	// Use this for initialization
	void Start () {
        reloadClip = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(rotationSpeed);
	}

    public void playClip()
    {
        reloadClip.Play();
    }
}