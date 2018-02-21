using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour {

	private float inputDirection;	// x-value of MoveVector
	private float verticalVelocity;	// y-value of MoveVector

	private float speed = 5.0f;
	private float gravity = 0.5f;
	private float jumpForce = 10.0f;
	private bool secondJumpAvail = false;

	private Vector3 moveVector; // (float,float,float) value
	private Vector3 lastMotion;
	private CharacterController controller;

	// Use this for initialization
	void Start ()
	{
		controller = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		isControllerGrounded();
		inputDirection = Input.GetAxis ("Horizontal")*speed;

		if (isControllerGrounded())
		{
			verticalVelocity = 0;
			moveVector.x = inputDirection;

			if (Input.GetKeyDown (KeyCode.Space))
			{
				verticalVelocity = jumpForce;	// make player jump only when grounded
				secondJumpAvail = true;
				Debug.Log ("Jump!");
			}

		} 
		else
		{
			verticalVelocity -= gravity;	// accelerates instead of constant velocity

			if (Input.GetKeyDown (KeyCode.Space) && secondJumpAvail)
			{
				verticalVelocity = jumpForce;	// make player jump only when grounded
				secondJumpAvail = false;
				Debug.Log ("2nd Jump!");
			}

			moveVector.x = lastMotion.x;
		}
		moveVector.y = verticalVelocity;
		// moveVector = new Vector3 (inputDirection, verticalVelocity, 0);
		controller.Move (moveVector*Time.deltaTime); // where exactly you moving in the (x,y,z)
		lastMotion = moveVector;
	}

	private bool isControllerGrounded ()
	{
		Vector3 leftRayStart;
		Vector3 rightRayStart;

		leftRayStart = controller.bounds.center;
		rightRayStart = controller.bounds.center;

		leftRayStart.x -= controller.bounds.extents.x;	// extend ray to left of cube
		rightRayStart.x += controller.bounds.extents.x;	// extend ray to right of cube

		// Debug.DrawRay (leftRayStart, Vector3.down, Color.red);
		// Debug.DrawRay (rightRayStart, Vector3.down, Color.green);

		if (Physics.Raycast (leftRayStart, Vector3.down, (controller.height / 2) + 0.09f)) 
			return true;
	
		if (Physics.Raycast (rightRayStart, Vector3.down, (controller.height / 2) + 0.09f)) 
			return true;
		
		return false;
	}

	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (controller.collisionFlags == CollisionFlags.Sides)
		{
			if (Input.GetKeyDown (KeyCode.Space))
			{
				Debug.DrawRay (hit.point, hit.normal, Color.red, 2.0f);
				moveVector = hit.normal * speed;	// hit.normal is a unit vector
				verticalVelocity = jumpForce;
				secondJumpAvail = true;
			}
		}

		// Collectibles
		switch (hit.gameObject.tag)
		{
		case "Coin":
			Destroy (hit.gameObject);
			speed += 0.5f;
			break;
		case "JumpPad":
			verticalVelocity = jumpForce * 3.85f;
			secondJumpAvail = false;
			break;
		default:
			break;
		}
	}
}