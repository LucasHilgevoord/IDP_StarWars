using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour 
{
	[SerializeField] private Stat health;

	private void Awake ()
	{
		health.Initialize ();
	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "EnemyBullet")
		{
			health.CurrentVal -= 50 * Time.deltaTime;
		}
	}
}
//	void Update () 
//	{
//		if (Input.GetKeyDown (KeyCode.P)) 
//		{
//			health.CurrentVal -= 10;
//		}
//		if (Input.GetKeyDown (KeyCode.L)) 
//		{
//			health.CurrentVal += 10;
//		}
//	}

