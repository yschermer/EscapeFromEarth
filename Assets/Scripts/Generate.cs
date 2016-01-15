using UnityEngine;
using System.Collections;

public class Generate : MonoBehaviour {

	public GameObject obstacle;
	public GameObject point;
	int distance;

	// Use this for initialization
	void Start () {
		distance = 0;

		InvokeRepeating ("CreateObstacle", 0.1f, Random.Range(0.5f, 1f));
		InvokeRepeating ("CreatePoint", 0.1f, Random.Range(0.5f, 1f));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	void OnGUI()
	{
		GUI.color = Color.white;
		GUILayout.Label ("Distance: " + distance.ToString());
	}

	void CreateObstacle()
	{
		distance++;
		Instantiate (obstacle);
	}

	void CreatePoint(){
		Instantiate (point);
	}
}
