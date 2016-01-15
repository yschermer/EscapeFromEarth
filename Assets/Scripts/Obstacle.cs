using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	private float rangeLeft = -3.5f;
	private float rangeRight = 3.5f;
	private float range;

	// Use this for initialization
	void Start () {
		range = Random.Range (rangeLeft, rangeRight);
		this.gameObject.transform.position = new Vector2 (range, 5);	
	}
	
	// Update is called once per frame
	void Update () {
		if (this.gameObject.transform.position.y < -3) {
			DestroyObject (this.gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Point") {
			this.gameObject.transform.rotation = new Vector2 (0, 0);
		}
	}
}
