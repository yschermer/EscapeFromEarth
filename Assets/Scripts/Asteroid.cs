using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Asteroid : MonoBehaviour {

    // Poop
    public Sprite asteroid_1;
    public Sprite asteroid_2;
    public Sprite asteroid_3;

    // Use this for initialization
    void Start () {
        float minPosition = -3.5f;
        float maxPosition = 3.5f;
        float maxRotation = 359;
        int obstacleToSelect = Random.Range(0,3);

        // Shit
        List<Sprite> obstacles = new List<Sprite>();
        obstacles.Add(asteroid_1);
        obstacles.Add(asteroid_2);
        obstacles.Add(asteroid_3);

        SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
        renderer.sprite = obstacles[obstacleToSelect];

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
