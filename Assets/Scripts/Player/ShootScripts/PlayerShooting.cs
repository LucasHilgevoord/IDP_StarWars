using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	
	[SerializeField] public GameObject bullet;
	[SerializeField] public Transform muzzleA;
	[SerializeField] public Transform muzzleB;
	[SerializeField] public Transform muzzleC;
	[SerializeField] public Transform muzzleD;

	private float fireRate = 1;
	private float fireCountdown = 0f;

	void Start ()
	{

	}

	void Update ()
	{
		if (Input.GetKeyDown("space"))
		{
			StartCoroutine(Shoot());
			fireCountdown = 1f / fireRate;
		}

		fireCountdown -= Time.deltaTime;

	}

	IEnumerator Shoot()
	{
		Debug.Log("Test");
		Instantiate(bullet, muzzleA.position, muzzleA.rotation);
		Instantiate(bullet, muzzleC.position, muzzleC.rotation);
		yield return new WaitForSeconds(1f);
		Instantiate(bullet, muzzleB.position, muzzleB.rotation);
		Instantiate(bullet, muzzleD.position, muzzleD.rotation);
    }

}