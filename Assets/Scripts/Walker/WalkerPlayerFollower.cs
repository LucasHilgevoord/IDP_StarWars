using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerPlayerFollower : MonoBehaviour {

    public Transform target;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(target);
        if (target.position.y < transform.position.y) {
            transform.rotation = Quaternion.Euler(0, target.position.y, target.position.z);
        }
        else
        {

        }
    }
}
