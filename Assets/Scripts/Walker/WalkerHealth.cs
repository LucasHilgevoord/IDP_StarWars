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
            Destroy(gameObject, 1f);
        }
	}

    void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "PlayerBullet")
        {
            DestroyObject(other.gameObject);
            maxHealth = (maxHealth - bulletDamage);
        }
    }
}
