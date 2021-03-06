﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour {

    [Tooltip("In ms^-1")] [SerializeField] private float Speed = 4f;   //Speed at which the ship will move along x/y-axis
    [SerializeField] private float xBoundaries = 5f;     //Used as min/max for clamp function so ship does not go off screen on x-axis
    [SerializeField] private float yBoundaries = 5f;     //Used as min/max for clamp function so ship does not go off screen on y-axis

    [SerializeField] private float rotationYFactor = 5f;    //This number is used as a factor to keep the ship facing forward when moving on the x-axis
    [SerializeField] private float rotationZFactor;         //Rotates ship on z-axis when it moves on x-axis
    [SerializeField] private float rotationXFactor = -5f;   //This number is used as a factor to keep the ship facing forward when moving on the y-axis
    [SerializeField] private float xNoseControl = -5f;      //Helps with the ships nose movement on the x-axis
    
    private float yThrow;
    private float xThrow;
    private Boolean hasNotCollided;

    // Use this for initialization
    void Start () {
        hasNotCollided = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (hasNotCollided)
        {
            MovementOnXAxis();
            MovementOnYAxis();
            Rotation();
        }
    }

    //Controls the rotation of the ship so that it's always facing forward
    private void Rotation()
    {
        float finalXRotation = rotationXFactor * transform.localPosition.y + yThrow * xNoseControl;
        float finalYRotation = rotationYFactor * transform.localPosition.x;
        float finalZRotation = xThrow * rotationZFactor;
        transform.localRotation = Quaternion.Euler(finalXRotation, finalYRotation, finalZRotation);
    }

    //Controls the movement on the y-axis
    private void MovementOnYAxis()
    {
        //Value between -1 and 1. GetAxis returns the value of the virtual axis. Value changes when you press
        //W, S, UpArrow, DownArrow
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        //Calculate where on the y-axis the ship should be. Time.delta time makes it frame rate independent
        float yOffset = Speed * yThrow * Time.deltaTime;

        //The new y position of the ship
        float newYPosition = yOffset + transform.localPosition.y;

        //Moves the ship
        transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Clamp(newYPosition, -yBoundaries, yBoundaries), transform.localPosition.z);
        
    }

    //Controls the movement on the x-axis
    private void MovementOnXAxis()
    {
        //Value between -1 and 1. GetAxis returns the value of the virtual axis. Value changes when you press
        //A, D, <--, -->
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        
        //Calculate where on the x-axis the ship should be. Time.delta time makes it frame rate independent
        float xOffset = Speed * xThrow * Time.deltaTime;

        //The new x position of the ship
        float newXPosition = xOffset + transform.localPosition.x;

        //Moves the ship
        transform.localPosition = new Vector3(Mathf.Clamp(newXPosition, -xBoundaries, xBoundaries), transform.localPosition.y, transform.localPosition.z);
        
    }

    //Method is called when the ship collides with something
    private void recieveCollisionMessage(Boolean hasCollided)
    {
        hasNotCollided = hasCollided;
    }
}
