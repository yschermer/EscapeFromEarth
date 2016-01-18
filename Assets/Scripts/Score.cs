using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Diagnostics;

public class Score : MonoBehaviour {

    public Text timeText;
    public Text distanceText;
    Stopwatch timer;
    int distance;

	// Use this for initialization
	void Start () {
        timeText = timeText.GetComponent<Text>();
        timer = new Stopwatch();
        timer.Start();

        distanceText = distanceText.GetComponent<Text>();
        distance = 0;
        InvokeRepeating("IncreaseDistanceTravelled", 0.1f, 0.1f);
	}
	
	// Update is called once per frame
	void Update () {
        timeText.text = string.Format("{0} m {1} s", timer.Elapsed.Minutes, timer.Elapsed.Seconds);
        distanceText.text = string.Format("{0} km", distance);
	}

    void IncreaseDistanceTravelled()
    {
        distance++;
    }
}
