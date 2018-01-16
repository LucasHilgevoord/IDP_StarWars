using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	[SerializeField]float movementSpeed = 20f;
	[SerializeField]float turnSpeed = 60f;

	Transform obT;

	void Awake()
	{
		obT = transform;
	}

	void Update () 
	{
		Turn();
		Thrust();
	}

	void Turn()
	{
		float yaw = turnSpeed * Time.deltaTime * Input.GetAxis ("Horizontal");
		float pitch = turnSpeed * Time.deltaTime * Input.GetAxis ("Pitch");
		float roll = turnSpeed * Time.deltaTime * Input.GetAxis ("Roll");

		obT.Rotate (pitch, yaw, roll);
	}

	void Thrust()
	{
		if(Input.GetAxis("Vertical") > 0)
			obT.position += obT.forward * movementSpeed * Time.deltaTime * Input.GetAxis("Vertical");
	}

}