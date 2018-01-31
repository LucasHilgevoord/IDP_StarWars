using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerHealth : MonoBehaviour {

    private int maxHealth = 1;
    private int bulletDamage = 1;
    [SerializeField]
    private GameObject explosionPoint;
    [SerializeField]
    public GameObject explosion;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(maxHealth);
		if (maxHealth <= 0)
        {
            Instantiate(explosion, explosionPoint.transform.position, Quaternion.identity);
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
