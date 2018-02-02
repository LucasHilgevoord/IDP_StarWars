using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

	[SerializeField] ParticleSystem muzzleFlashA;
	[SerializeField] ParticleSystem muzzleFlashB;
	[SerializeField] GameObject bullet;
	[SerializeField] Transform muzzle1;
	[SerializeField] Transform muzzle2;
	[SerializeField] Transform muzzle3;
	[SerializeField] Transform muzzle4;
	[SerializeField] AudioClip shootSound;

	private AudioSource audioSource;
	private float fireRate = 1;
	private float fireCountdown = 0f;

	void Start ()
	{
		audioSource = GetComponent<AudioSource>();
	}

	void Update ()
	{
		if (fireCountdown <= 0f && (Input.GetKey("space")))
		{
			StartCoroutine(Shoot());
			fireCountdown = 1f / fireRate;
		}
		fireCountdown -= Time.deltaTime;
	}

	IEnumerator Shoot()
	{
		muzzleFlashA.Play ();
		muzzleFlashB.Play ();
		audioSource.PlayOneShot(shootSound, 0.5F);
		Instantiate(bullet, muzzle1.position, muzzle1.rotation);
		Instantiate(bullet, muzzle3.position, muzzle3.rotation);
		yield return new WaitForSeconds(0.5f);
		Instantiate(bullet, muzzle2.position, muzzle2.rotation);
		Instantiate(bullet, muzzle4.position, muzzle4.rotation);
		audioSource.PlayOneShot(shootSound, 0.7F);
	}
}