using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

//A playerUnit is a unit controlled by a player
//This could be a character in an FPS, a zergling in a RTS
//Or a scout in a TBS




public class PlayerUnit : NetworkBehaviour {



	private float inputDirection; //X value of our MoveVector
	private float verticalVelocity; // Y value of our MoveVector

	private float speed = 5.0f;
	//private float gravity = 1.0f;

	private Vector3 moveVector;
	private CharacterController controller;



	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//This function runs on ALL PlayerUnits -- not just the ones that i own

		//How do I verify that I am allowed to mess around with this object?

		if (hasAuthority == false) 
		{

			return;

		}

		/*
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			 this.transform.Translate (0,1,0);

			//Space was hit-- we could instruct the server 
			//to do something with our unit.

		}
		*/
	



	
		inputDirection = Input.GetAxis ("Horizontal") * Time.deltaTime * 10.0f;
		moveVector = new Vector3 (inputDirection,0,0);
		//controller.transform.Translate(inputDirection, 0, 0);
		controller.Move(moveVector);



		/*
		if (Input.GetKeyDown(KeyCode.B)) {
			Destroy (gameObject);
		}
		*/



	}
}
