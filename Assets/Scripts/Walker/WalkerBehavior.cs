using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerBehavior : MonoBehaviour
{

    public Transform target;
    public Transform body;

    private int range = 20;
    public Transform partToRotate;

    private float fireRate = 3f;
    private float fireCountdown = 0f;

    public GameObject bulletPrefab;
    public Transform firePointA;
    public Transform firePointB;
    public Transform firePointC;
    public Transform firePointD;

    // Update is called once per frame
    void Update()
    {
        //Vind Target
        //-=VERSIMPEL=-
        if (Vector3.Distance(transform.position, target.position) < range)
        {
            if (target.position.y < transform.position.y)
            {
                //Als de player lager is dan y0 dan blijft de y0.
                var lookPos = target.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                partToRotate.rotation = Quaternion.Slerp(partToRotate.rotation, rotation, Time.deltaTime * 5);
            }
            else
            {
                //Als de player hoger is dan y0 dan kijkt blijft hij volgen.
                var lookPos = target.position - transform.position;
                var rotation = Quaternion.LookRotation(lookPos);
                partToRotate.rotation = Quaternion.Slerp(partToRotate.rotation, rotation, Time.deltaTime * 5);
            }

            //Schiet wanneer player in range is en de cooldown op is.
            if (fireCountdown <= 0f)
            {
                ShootA();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }
        else
        {
            //Als Player niet in range is dan blijft hij de body volgen.
            partToRotate.rotation = Quaternion.Slerp(partToRotate.rotation, body.rotation, Time.deltaTime * 5);
        }
    }

    void ShootA()
    {
        //Instantiate(bulletPrefab, firePointA.position, firePointA.rotation);
        //Instantiate(bulletPrefab, firePointB.position, firePointB.rotation);
        //Instantiate(bulletPrefab, firePointC.position, firePointC.rotation);
        //Instantiate(bulletPrefab, firePointD.position, firePointD.rotation);
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}