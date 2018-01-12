using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour 
{
	[SerializeField]Transform target;
	[SerializeField]Vector3 defDistance = new Vector3 (0f, 2f, 10f);
	[SerializeField]float targetDistance = 10f;
//	[SerializeField]float targetRotation = 10f;

	Transform obT;

	private Vector3 velocity = Vector3.one;

	void Awake()
	{
		obT = transform;
	}

	void LateUpdate()
	{
		SmoothFollow ();
	}

	void SmoothFollow()
	{
		Vector3 toPos = target.position + (target.rotation * defDistance);
		Vector3 curPos = Vector3.SmoothDamp(obT.position,toPos, ref velocity, targetDistance);
		obT.position = curPos;

		obT.LookAt(target, target.up);
	}

}
