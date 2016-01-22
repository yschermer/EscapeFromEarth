using UnityEngine;
using System.Collections;

public class Gametest : MonoBehaviour {

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int score = 90;
            string username = "google";

            HighScores.AddNewHighscore(username, score);
      
        }
    }
    
    	
}
