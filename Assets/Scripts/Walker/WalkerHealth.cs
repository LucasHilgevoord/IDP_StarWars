using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerHealth : MonoBehaviour {

    [SerializeField] public int maxHealth = 50;
    [SerializeField] public int bulletDamage = 1;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (maxHealth <= 0)
        {
            Destroy(gameObject);
        }
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "PlayerBullet")
        {
            DestroyObject(other.gameObject);
            maxHealth = (maxHealth - bulletDamage);
        }
        if (other.gameObject.tag == "Player")
        {
            maxHealth = 0;
        }
    }
}
