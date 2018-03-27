using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour {

    [Tooltip("In ms^-1")] [SerializeField] private float xSpeed = 4f;   //Speed at which the ship will move along x-axis
    [Tooltip("In ms^-1")] [SerializeField] private float ySpeed = 4f;   //Speed at which the ship will move along y-axis

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        MovementOnXAxis();
        MovementOnYAxis();
    }

    private void MovementOnYAxis()
    {
        //Value between -1 and 1. GetAxis returns the value of the virtual axis. Value changes when you press
        //W, S, UpArrow, DownArrow
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        //Calculate where on the y-axis the ship should be. Time.delta time makes it frame rate independent
        float yOffset = ySpeed * yThrow * Time.deltaTime;

        //The new y position of the ship
        float newYPosition = yOffset + transform.localPosition.y;

        //Moves the ship
        transform.localPosition = new Vector3(transform.localPosition.x, newYPosition, transform.localPosition.z);
    }

    private void MovementOnXAxis()
    {
        //Value between -1 and 1. GetAxis returns the value of the virtual axis. Value changes when you press
        //A, D, <--, -->
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");

        //Calculate where on the x-axis the ship should be. Time.delta time makes it frame rate independent
        float xOffset = xSpeed * xThrow * Time.deltaTime;

        //The new x position of the ship
        float newXPosition = xOffset + transform.localPosition.x;

        //Moves the ship
        transform.localPosition = new Vector3(newXPosition, transform.localPosition.y, transform.localPosition.z);
    }
}
