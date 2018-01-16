using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {

<<<<<<< HEAD
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
=======
    public float bulletSpeed = 20f;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
        Destroy(gameObject, 5);
    }
>>>>>>> b2fae93acdc7e8b74d36a145334d9925ce6ff469
}
