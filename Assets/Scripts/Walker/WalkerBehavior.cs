using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerBehavior : MonoBehaviour
{
    [SerializeField] public Transform target;
    [SerializeField] public Transform body;
    [SerializeField] public Transform head;

    [SerializeField] public int range = 20;
    [SerializeField] public Transform partToRotate;

    [SerializeField] public float fireRate = 3f;
    private float fireCountdown = 0f;

    [SerializeField] public GameObject bulletPrefab;
    [SerializeField] public Transform firePointA;
    [SerializeField] public Transform firePointB;
    [SerializeField] public Transform firePointC;
    [SerializeField] public Transform firePointD;

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
                Shoot();
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

    void Shoot()
    {
        Instantiate(bulletPrefab, firePointA.position, head.rotation);
        Instantiate(bulletPrefab, firePointB.position, head.rotation);
        //Instantiate(bulletPrefab, firePointC.position, head.rotation);
        //Instantiate(bulletPrefab, firePointD.position, head.rotation);
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}