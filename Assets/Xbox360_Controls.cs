// XBOX 360 CONTROLLER CODE SETUP FOR THE UNITY 3D ENGINE IN C SHARP
// THIS HAS BEEN WRITTEN BY KYLE D'AOUST FOR FREE AND EDUCATIONAL USE, ROYALTY FREE.
// FEEL FREE TO USE THIS CODE IN ANY OF YOUR PROJECTS

using UnityEngine;
using System.Collections;

public class Xbox360_Controls : MonoBehaviour 
{
	// These are used to modify the player movement speed, and rotation speed.
	public float PlayerMovementSpeed = 30;
	public float PlayerRotationSpeed = 180;
	
	// I seperated Movement and Button inputs into seperate functions, it makes for easier debugging
	void Update ()
	{
		Movement();
		UserInputs();
	}
	
	// This function handles the Movement calculations. You can adjust the code to work with different AXES if preferred.
	// Right Thumbstick uses the 4th(Vertical) and 5th(Horizontal) Input Joystick Axes, and the Left Thumbstick uses the X(Horizontal) and Y(Vertical) Input Joystick Axes.
	// For movement the Vertical Axis is read from moving the LEFT THUMBSTICK up and down,
	// the Horizontal Axis is read from moving the LEFT THUMBSTICK left and right.
	// For Rotation I have it reading from the RIGHT THUMBSTICK.
	void Movement()
	{
		// This line is for vertical movement, right now its on the Z AXIS.
		transform.Translate(0,0,Input.GetAxis("Vertical") * Time.deltaTime * PlayerMovementSpeed);
		
		// This line is for horizontal movement, right now its on the X AXIS. When combined with vertical movement it can be used for Strafing.
		transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * PlayerMovementSpeed,0,0);
		
		// This line is for rotation, right now its on the Y AXIS. 
		transform.Rotate(0,Input.GetAxis("RightStick") * Time.deltaTime * PlayerRotationSpeed,0);
	}
	
	// This function handles the Inputs from the buttons on the controller
	void UserInputs()
	{
		
		if(Input.GetAxis("360_HorizontalDPAD")>0.001)
		{
			Debug.Log ("Right D-PAD Button!");
		}
		
		// Left D-PAD Button is activated when pressure is under 0, or the dead zone.
		if(Input.GetAxis("360_HorizontalDPAD")<0)
		{
			Debug.Log("Left D-PAD Button!");
		}
		
		// Up D-PAD Button is activated when pressure is above 0, or the dead zone.
		if(Input.GetAxis("360_VerticalDPAD")>0.001)
		{
			Debug.Log ("Up D-PAD Button!");
		}
		
		// Down D-PAD Button is activated when pressure is under 0, or the dead zone.
		if(Input.GetAxis("360_VerticalDPAD")<0)
		{
			Debug.Log("Down D-PAD Button!");
		}
	}
}