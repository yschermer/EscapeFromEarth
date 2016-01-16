using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	private float cameraLimitRight = 3.5f;
	private float cameraLimitLeft = -3.5f;

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
        float distance = 0.15f;

        // Jump
        if (Input.GetKey ("left")) 
		{
			if (this.gameObject.transform.position.x > cameraLimitLeft) 
			{
				this.gameObject.transform.position = new Vector2 ((this.gameObject.transform.position.x - distance), this.gameObject.transform.position.y);
			}
		} 
		else if (Input.GetKey ("right")) 
		{
			if (this.gameObject.transform.position.x < cameraLimitRight) 
			{
				this.gameObject.transform.position = new Vector2 ((this.gameObject.transform.position.x + distance), this.gameObject.transform.position.y);
			}
		}
	}

	// Die by collision
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Obstacle") {
			Die ();
		} else if(other.gameObject.tag == "Sunlight") {
			Destroy (other.gameObject);
			// Punten verdienen
		}
	}

	void Die(){
        SceneManager.LoadScene("Play");
	}
}
