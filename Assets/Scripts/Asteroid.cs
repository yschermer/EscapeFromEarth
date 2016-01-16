﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Asteroid : MonoBehaviour {


    // Use this for initialization
    void Start () {
        float minPosition = -3.5f;
        float maxPosition = 3.5f;
        float maxRotation = 359;



        gameObject.transform.position = new Vector2 (Random.Range(minPosition, maxPosition), 5);
        gameObject.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, maxRotation));
	}
	
	// Update is called once per frame
	void Update () {
		if (this.gameObject.transform.position.y < -4) {
			DestroyObject (this.gameObject);
		}
	}
}