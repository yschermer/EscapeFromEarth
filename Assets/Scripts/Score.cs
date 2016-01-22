using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Diagnostics;

public class Score : MonoBehaviour {

    public static int distance;
    public static bool gamePause;

    public Text timeText;
    public Text distanceText;
    public Button pauseButton;

    Stopwatch timer;

	// Use this for initialization
	void Start () {
        timeText = timeText.GetComponent<Text>();
        timer = new Stopwatch();
        timer.Start();

        gamePause = false;
        pauseButton = pauseButton.GetComponent<Button>();

        distanceText = distanceText.GetComponent<Text>();
        distance = 0;
        InvokeRepeating("IncreaseDistanceTravelled", 0.1f, 0.1f);
	}
	
	// Update is called once per frame
	void Update () {
        if(Time.timeScale == 0)
        {
            timer.Stop();
        }

        timeText.text = string.Format("{0} m {1} s", timer.Elapsed.Minutes, timer.Elapsed.Seconds);
        distanceText.text = string.Format("{0} km", distance);
	}

    void IncreaseDistanceTravelled()
    {
        distance++;
    }

    public void PauseGame()
    {
        if (gamePause)
        {
            Time.timeScale = 1;
            timer.Start();
            gamePause = false;
        }
        else
        {
            Time.timeScale = 0;
            timer.Stop();
            gamePause = true;
        }
    }
}
