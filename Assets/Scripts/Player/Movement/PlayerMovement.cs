using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
	[SerializeField] float movementSpeed;
	[SerializeField] float turnSpeed;

	Transform objT;

	void Awake()
	{
		objT = transform;
	}

	void Update () 
	{
		Turn();
		Thrust();

		Vector3 clampedPosition = objT.position;
		clampedPosition.y = Mathf.Clamp (transform.position.y, -1f, 30f);
		transform.position = clampedPosition;
	}

	void Turn()
	{
		float yaw = turnSpeed * Time.deltaTime * Input.GetAxis ("Horizontal");
		float pitch = turnSpeed * Time.deltaTime * Input.GetAxis ("Pitch");
		float roll = turnSpeed * Time.deltaTime * Input.GetAxis ("Roll");

		objT.Rotate (pitch, yaw, roll);
	}

	void Thrust()
	{
		if(Input.GetAxis("Vertical") > 0)
			objT.position += objT.forward * movementSpeed * Time.deltaTime * Input.GetAxis("Vertical");
	}

}