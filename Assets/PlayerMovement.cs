using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour {

    [Tooltip("In ms^-1")] [SerializeField] private float Speed = 4f;   //Speed at which the ship will move along x/y-axis
    [SerializeField] private float xBoundaries = 5f;     //Used as min/max for clamp function so ship does not go off screen on x-axis
    [SerializeField] private float yBoundaries = 5f;     //Used as min/max for clamp function so ship does not go off screen on y-axis
    [SerializeField] private float rotationXFactor = -5f;   //This number is used as a factor to keep the ship facing forward when moving on the y-axis
    [SerializeField] private float xNoseControl = -5f;      //Helps with the ships nose movement on the x-axis
    private float yThrow;
    private float xThrow;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        MovementOnXAxis();
        MovementOnYAxis();
        Rotation();
    }

    private void Rotation()
    {
        float finalXRotation = rotationXFactor * transform.localPosition.y + yThrow * xNoseControl;
        transform.localRotation = Quaternion.Euler(finalXRotation, 0f, 0f);
    }

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
}
