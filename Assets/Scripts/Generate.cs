using UnityEngine;
using System.Collections;

public class Generate : MonoBehaviour {

	public GameObject asteroid1;
    public GameObject asteroid2;
    public GameObject asteroid3;
    public GameObject meteor;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("CreateAsteroid", 0.1f, Random.Range(0.7f, 1.2f));
        InvokeRepeating("CreateMeteor", 5f, 5f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	void CreateAsteroid()
	{
		Instantiate (asteroid1);
        Instantiate(asteroid2);
        Instantiate(asteroid3);
    }

    void CreateMeteor()
    {
        Instantiate(meteor);
    }
}
