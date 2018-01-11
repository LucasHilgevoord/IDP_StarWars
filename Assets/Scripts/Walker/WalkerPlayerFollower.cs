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
        
        if (target.position.y < transform.position.y) {
            var lookPos = target.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10);
        }
        else
        {
            var lookPos = target.position - transform.position;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10);
        }
    }
}
