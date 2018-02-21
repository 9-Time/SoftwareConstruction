using System.Collections;
using UnityEngine;

public class CameraMotor : MonoBehaviour 
{
	public Transform lookAt;

	private float smoothSpeed = 0.2f;
	private Vector3 offset = new Vector3 (0, 0, -12.0f);
	
	// Update is called once per frame
	void LateUpdate () 
	{
		Vector3 desiredPostion = lookAt.transform.position + offset;
		transform.position = Vector3.Lerp (transform.position, desiredPostion, smoothSpeed);
	}
}
