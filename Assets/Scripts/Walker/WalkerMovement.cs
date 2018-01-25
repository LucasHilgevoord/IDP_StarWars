using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkerMovement : MonoBehaviour {

    private NavMeshAgent NavM;
    private float PathResetTime = 3;
    private bool isWalking = false;

	// Use this for initialization
	void Start () {
        NavM = GetComponent<NavMeshAgent>();
       // GetRandomPos();
    }

    void Update()
    {
        if (!isWalking)
            StartCoroutine(CountdownNewPath());

    }

    Vector3 GetRandomPos ()
    {
        //PathResetTime = Random.Range(3, 8);
        float x = Random.Range(-50, 50);
        float z = Random.Range(-50, 50);

        Vector3 pos = new Vector3(x, 0, z);
        return pos;
    }

    IEnumerator CountdownNewPath()
    {
        isWalking = true;
        yield return new WaitForSeconds(PathResetTime);
        GetNewPath();
        isWalking = false;
    }

    void GetNewPath()
    {
        NavM.SetDestination(GetRandomPos());
    }
}
