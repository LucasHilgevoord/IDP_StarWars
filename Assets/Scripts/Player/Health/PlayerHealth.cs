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

	void Update()
	{
		if (health.CurrentVal == 0) 
		{
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "PlayerBullet")
		{
			health.CurrentVal -= 50 * Time.deltaTime;
		}
	}
}

