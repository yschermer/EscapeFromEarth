using UnityEngine;
using System.Collections;

public class Point : MonoBehaviour {

	private float rangeLeft = -3.45f;
	private float rangeRight = 3.45f;

	// Use this for initialization
	void Start () {
		this.gameObject.transform.position = new Vector2 (Random.Range(rangeLeft, rangeRight), 5);	
	}

	// Update is called once per frame
	void Update () {
		if (this.gameObject.transform.position.y < -3) {
			DestroyObject (this.gameObject);
		}
	}
}
