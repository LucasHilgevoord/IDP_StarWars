using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour 
{
	[SerializeField]Transform target;
	[SerializeField]Vector3 defDistance = new Vector3 (0f, 2f, 10f);
	[SerializeField]float targetDistance = 10f;
	[SerializeField]float targetRotation = 10f;
	Transform obT;

	void Awake()
	{
		obT = transform;
	}

	void LateUpdate()
	{
		Vector3 toPos = target.position + (target.rotation * defDistance);
		Vector3 curPos = Vector3.Lerp (obT.position, toPos, targetDistance * Time.deltaTime);
		obT.position = curPos;

		Quaternion toRot = Quaternion.LookRotation(target.position - obT.position, target.up);
		Quaternion curRot = Quaternion.Slerp (obT.rotation, toRot, targetRotation * Time.deltaTime);
		obT.rotation = curRot;
	}

}
