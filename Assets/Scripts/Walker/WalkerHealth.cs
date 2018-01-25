using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerHealth : MonoBehaviour {

    public int maxHealth = 20;
    public int curHealth = 20;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (curHealth == 0)
        {
            Destroy(gameObject, 2f);
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "playerBullet")
        {
            DestroyObject(other.gameObject);
            Destroy(gameObject);
        }
    }
}
