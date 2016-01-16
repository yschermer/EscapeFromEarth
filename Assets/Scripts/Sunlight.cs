using UnityEngine;
using System.Collections;

public class Sunlight : MonoBehaviour {

	private float rangeLeft = -3.5f;
	private float rangeRight = 3.5f;

	// Use this for initialization
	void Start () {
		this.gameObject.transform.position = new Vector2 (Random.Range(rangeLeft, rangeRight), 5);	
	}

	// Update is called once per frame
	void Update () {
		if (this.gameObject.transform.position.y < -4) {
			DestroyObject (this.gameObject);
		}
	}
}
