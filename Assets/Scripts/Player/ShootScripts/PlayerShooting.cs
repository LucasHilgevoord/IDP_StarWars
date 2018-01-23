using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	
	[SerializeField] GameObject Muzzle;
	[SerializeField] GameObject Bullet;

	void Start ()
	{

	}

	void Update ()
	{
		if (Input.GetKeyDown("space"))
		{
			Instantiate (Bullet, Muzzle.transform.position, Muzzle.transform.rotation);

			Destroy(Bullet, 3.0f);
		}
	}
}