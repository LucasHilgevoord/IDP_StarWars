using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkerMovement : MonoBehaviour {

    NavMeshAgent NavM;
    [SerializeField] public float PathResetTime;
    [SerializeField] public static bool isWalking = false;

	// Use this for initialization
	void Start () {
        NavM = GetComponent<NavMeshAgent>();
	}

    void Update()
    {
        if (!isWalking)
            StartCoroutine(CountdownNewPath());

    }

    Vector3 GetRandomPos ()
    {
        float x = Random.Range(-20, 20);
        float z = Random.Range(-20, 20);

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
