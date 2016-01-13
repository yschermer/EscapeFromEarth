using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private float amountToMove = 0.25f;
	private float surfaceLimitRight = 3.45f;
	private float surfaceLimitLeft = -3.45f;

	void Start ()
	{
		// gameObject
		float x = 0;
		float y = -2;
		float z = 0;
		this.gameObject.transform.position = new Vector3 (x, y, z);
	}

	// Update is called once per frame
	void Update ()
	{
		// Jump
		if (Input.GetKey ("left")) 
		{
			if (this.gameObject.transform.position.x > surfaceLimitLeft) 
			{
				this.gameObject.transform.position = new Vector2 ((this.gameObject.transform.position.x - amountToMove), this.gameObject.transform.position.y);
			}
		} 
		else if (Input.GetKey ("right")) 
		{
			if (this.gameObject.transform.position.x < surfaceLimitRight) 
			{
				this.gameObject.transform.position = new Vector2 ((this.gameObject.transform.position.x + amountToMove), this.gameObject.transform.position.y);
			}
		}
	}

	// Die by collision
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Obstacle") {
			Die ();
		} else if(other.gameObject.tag == "Light") {
			Destroy (other.gameObject);
			// Punten verdienen
		}
	}

	void Die(){
		Application.LoadLevel ("Play");
	}
}
