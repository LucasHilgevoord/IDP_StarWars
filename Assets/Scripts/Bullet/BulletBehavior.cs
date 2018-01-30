﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {

    public float bulletSpeed = 20f;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
        Destroy(gameObject, 4);
    }
}
