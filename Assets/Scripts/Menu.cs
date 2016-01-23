using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Menu : MonoBehaviour {

    public Canvas menu;
    public Button play;
    public Button home;
    public Button submitUsername;
    public Text distanceText;
    public Text distance;
    public Text timeText;
    public Text time;
    public InputField username;

    // Use this for initialization
    void Start () {
        menu = menu.GetComponent<Canvas>();
        play = play.GetComponent<Button>();

        if (Application.loadedLevelName == "Play")
        {
            // For testing
            //PlayerPrefs.DeleteKey("User");
            // For testing

            menu.enabled = false;

            home = home.GetComponent<Button>();          
            distanceText = distanceText.GetComponent<Text>();
            distance = distance.GetComponent<Text>();
            timeText = timeText.GetComponent<Text>();
            time = time.GetComponent<Text>();
            username = username.GetComponent<InputField>();
            submitUsername = submitUsername.GetComponent<Button>();

            if (PlayerPrefs.HasKey("User"))
            {
                HideComponent(username);
                HideComponent(submitUsername);
            }
        }
        else
        {
            menu.enabled = true;
        }
    }

    private void HideComponent(Component component)
    {
        component.transform.position = new Vector2(component.transform.position.x, -6);
    }

    void Update()
    {
        if(Time.timeScale == 0 && Application.loadedLevelName == "Play")
        {
            distance.text = distanceText.text;
            time.text = timeText.text;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        menu.enabled = false;
        Time.timeScale = 1;
        Application.LoadLevel("Play");
    }

    public void ReturnToHome()
    {
        Application.LoadLevel("Menu");
    }

    public void ToHighscores()
    {
        Application.LoadLevel("Highscores");
    }

    public void OnSubmit()
    {
        PlayerPrefs.SetString("User", username.text);
        HighScores.AddNewHighscore(username.text, Score.distance);
        HideComponent(username);
        HideComponent(submitUsername);
    }
}
