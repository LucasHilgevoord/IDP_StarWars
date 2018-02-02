using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour 
{
	[SerializeField] private Stat health;
	[SerializeField] private GameObject explosionPoint;
	[SerializeField] private GameObject explosion;
	[SerializeField] AudioClip explosionSound;

	private AudioSource audioSource;

	void Start ()
	{
		audioSource = GetComponent<AudioSource>();
	}

	private void Awake ()
	{
		health.Initialize ();
	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "EnemyBullet")
		{
			health.CurrentVal -= 10 * Time.deltaTime;
		}

		if(col.gameObject.tag != "EnemyBullet")
		{
			health.CurrentVal = 0 * Time.deltaTime;
		}

		if(health.CurrentVal == 0) 
		{
			audioSource.PlayOneShot(explosionSound, 1f);
			Instantiate (explosion, explosionPoint.transform.position, Quaternion.identity);
			StartCoroutine(Reset ());
		}

	}

	IEnumerator Reset()
	{
		yield return new WaitForSeconds (0.5f);
		SceneManager.LoadScene ("b_scene");
	}
}
