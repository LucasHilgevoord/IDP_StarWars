﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour {

    private GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
	}

    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 newPosition = player.transform.position;
            newPosition.y = player.transform.position.y + 20;
            transform.position = newPosition;

            transform.rotation = Quaternion.Euler(90f, player.transform.eulerAngles.y, 0f);
        }
    }
}
