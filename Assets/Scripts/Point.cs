using UnityEngine;
using System.Collections;

public class Point : MonoBehaviour {

	private float rangeLeft = -3.5f;
	private float rangeRight = 3.5f;

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

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Obstacle") {
			this.gameObject.transform.rotation = Quaternion.Euler (0, 0, 0);
		}
	}
}
