using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkerMovement : MonoBehaviour {

    private NavMeshAgent navM;
    private float pathResetTime;
    private bool isWalking = false;

	// Use this for initialization
	void Start () {
        navM = GetComponent<NavMeshAgent>();
	}

    void Update()
    {
        if (!isWalking)
            StartCoroutine(countdownNewPath());

    }

    Vector3 getRandomPos ()
    {
        float x = Random.Range(-30, 30);
        float z = Random.Range(-30, 30);

        Vector3 pos = new Vector3(x, 0, z);
        return pos;
    }

    IEnumerator countdownNewPath()
    {
        isWalking = true;
        yield return new WaitForSeconds(pathResetTime);
        GetNewPath();
        isWalking = false;
    }

    void GetNewPath()
    {
        navM.SetDestination(getRandomPos());
    }
}
