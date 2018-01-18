using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour 
{
	[SerializeField]Transform target;
	[SerializeField]Vector3 defDistance = new Vector3 (0f, 2f, 10f);
	[SerializeField]float targetDistance = 15f;
	[SerializeField]float targetRotation = 15f;
	Transform objT;

	void Awake()
	{
 	 objT = transform;
	}

	void LateUpdate()
	{
		Vector3 toPos = target.position + (target.rotation * defDistance);
		Vector3 curPos = Vector3.Lerp (objT.position, toPos, targetDistance * Time.deltaTime);
		objT.position = curPos;

		Quaternion toRot = Quaternion.LookRotation(target.position - objT.position, target.up);
		Quaternion curRot = Quaternion.Slerp (objT.rotation, toRot, targetRotation * Time.deltaTime);
		objT.rotation = curRot;
	}

}