using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {

    public float bulletSpeed = 20f;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        //Vector3 dir = Vector3.forward * bulletSpeed * Time.deltaTime;
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
        //this.transform.up = dir;
        Destroy(gameObject, 5);
    }
}
