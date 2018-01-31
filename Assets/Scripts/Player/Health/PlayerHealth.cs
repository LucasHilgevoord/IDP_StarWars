using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour 
{
	[SerializeField] private Stat health;
	[SerializeField] private GameObject explosionPoint;
	[SerializeField] public GameObject explosion;

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
		if(col.gameObject.tag != "EnemyBullet")
		{
			health.CurrentVal = 0;
		}
	}


	void Update ()
	{
		if (health.CurrentVal <= 0) 
		{
			Instantiate (explosion, explosionPoint.transform.position, Quaternion.identity);
			Destroy (gameObject);
		}
	}
}