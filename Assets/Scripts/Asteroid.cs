using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Asteroid : MonoBehaviour {


    // Use this for initialization
    void Start () {
        gameObject.transform.position = new Vector2 (Random.Range(Initialization.minPositionX, Initialization.maxPositionX), 5);
        gameObject.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 359));
	}
	
	// Update is called once per frame
	void Update () {
		if (this.gameObject.transform.position.y < -4) {
			DestroyObject (this.gameObject);
		}
	}
}
