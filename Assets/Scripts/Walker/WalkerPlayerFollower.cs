using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerPlayerFollower : MonoBehaviour {

    public Transform target;
    private int range = 30;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(transform.position, target.position) < range)
        {
            if (target.position.y < transform.position.y)
            {
                var lookPos = target.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10);
                WalkerMovement.isWalking = false;
            }
            else
            {
                var lookPos = target.position - transform.position;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10);
            }
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.identity, Time.deltaTime * 5);
            WalkerMovement.isWalking = true;
        }
    }
}
