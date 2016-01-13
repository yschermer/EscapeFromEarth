using UnityEngine;
using System.Collections;

public class Generate : MonoBehaviour {

	public GameObject obstacle;
	public GameObject light;
	int distance;

	// Use this for initialization
	void Start () {
		distance = 0;

		InvokeRepeating ("CreateObstacle", 1f, 1.5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	void OnGUI()
	{
		GUI.color = Color.black;
		GUILayout.Label ("Distance: " + distance.ToString());
	}

	void CreateObstacle()
	{
		distance++;
		Instantiate (obstacle);
		Instantiate (light);
	}
}
