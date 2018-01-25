using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	
	[SerializeField] GameObject bullet;
	[SerializeField] Transform muzzle1;
	[SerializeField] Transform muzzle2;
	[SerializeField] Transform muzzle3;
	[SerializeField] Transform muzzle4;
	[SerializeField] Transform muzzle5;
	[SerializeField] Transform muzzle6;
	[SerializeField] Transform muzzle7;
	[SerializeField] Transform muzzle8;

	private float fireRate = 1;
	private float fireCountdown = 0f;

	void Start ()
	{

	}

	void Update ()
	{
		//if (Input.GetKey("space"))
		if (fireCountdown <= 0f && (Input.GetKey("space")))
		{
			StartCoroutine(Shoot());
			fireCountdown = 1f / fireRate;
		}

		fireCountdown -= Time.deltaTime;

	}

	IEnumerator Shoot()
	{
		Debug.Log("Test");
		Instantiate(bullet, muzzle1.position, muzzle1.rotation);
		Instantiate(bullet, muzzle3.position, muzzle3.rotation);
		Instantiate(bullet, muzzle5.position, muzzle5.rotation);
		Instantiate(bullet, muzzle7.position, muzzle7.rotation);
		yield return new WaitForSeconds(0.5f);
		Instantiate(bullet, muzzle2.position, muzzle2.rotation);
		Instantiate(bullet, muzzle4.position, muzzle4.rotation);
		Instantiate(bullet, muzzle6.position, muzzle6.rotation);
		Instantiate(bullet, muzzle8.position, muzzle8.rotation);
    }

}