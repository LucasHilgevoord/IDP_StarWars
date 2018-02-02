using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReload : MonoBehaviour {

	void Start () 
	{
		StartCoroutine ("Wait");
	}
	
	IEnumerator Wait()
	{
			yield return new WaitForSeconds (2);
		    SceneManager.LoadScene("level_01");			
	}
}
