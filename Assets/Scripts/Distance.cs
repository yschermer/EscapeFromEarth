using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Diagnostics;

public class Distance : MonoBehaviour {

    Text textComponent;
    int distance;

	// Use this for initialization
	void Start () {
        textComponent = GetComponent<Text>();
        distance = 0;

        InvokeRepeating("IncreaseDistanceTravelled", 0.1f, 0.1f);
	}
	
	// Update is called once per frame
	void Update () {
        textComponent.text = string.Format("Distance: {0} km", distance);
	}

    void IncreaseDistanceTravelled()
    {
        distance++;
    }
}
