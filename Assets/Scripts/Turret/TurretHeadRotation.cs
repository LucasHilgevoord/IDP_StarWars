using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHeadRotation : MonoBehaviour
{

    [SerializeField] public GameObject target;
    [SerializeField] public Transform body;
    [SerializeField] public Transform head;
    [SerializeField] public Transform gun;

    private int range = 20;
    private int rotationSpeed = 5;
    private float fireRate = 3;
    private float fireCountdown = 0f;

    [SerializeField] public GameObject bulletPrefab;
    [SerializeField] public Transform firePointA;
    [SerializeField] public Transform firePointB;

    [SerializeField] public AudioClip shootSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        target = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        //Zoek Target
        //-=VERSIMPEL=-
        if (Vector3.Distance(transform.position, target.transform.position) < range)
        {
            //Head Rotation
            var headLookPos = target.transform.position - transform.position;
            headLookPos.y = 0;
            var headRotate = Quaternion.LookRotation(headLookPos);
            head.rotation = Quaternion.Slerp(head.rotation, headRotate, Time.deltaTime * rotationSpeed);

            //Gun Rotation
            var gunLookPos = target.transform.position - transform.position;
            var gunRotate = Quaternion.LookRotation(gunLookPos);
            gun.rotation = Quaternion.Slerp(gun.rotation, gunRotate, Time.deltaTime * 2);

            //Shoot
            if (fireCountdown <= 0f)
            {
                StartCoroutine(Shoot());
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }
        else
        {
            //Als Player niet in range is dan blijft hij de body volgen.
            head.rotation = Quaternion.Slerp(head.rotation, body.rotation, Time.deltaTime * rotationSpeed);
        }
    }

    IEnumerator Shoot()
    {
        Debug.Log("Turret Shoot!");
        Instantiate(bulletPrefab, firePointA.position, gun.rotation);
        audioSource.PlayOneShot(shootSound, 0.7F);
        yield return new WaitForSeconds(1.5f);
        Instantiate(bulletPrefab, firePointB.position, gun.rotation);
        
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}