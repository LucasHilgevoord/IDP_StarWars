using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	[SerializeField]float movementSpeed = 10;

	Transform obT;

	void Awake()
	{
		obT = transform;
	}

	void Update () 
	{
		Thrust ();
	}

	void Thrust()
	{
		if(Input.GetAxis("Vertical") > 0)
		obT.position += obT.forward * movementSpeed * Time.deltaTime * Input.GetAxis("Vertical");
	}

}
