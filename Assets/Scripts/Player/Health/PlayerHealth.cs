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

