using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    public Canvas menu;
    public Button play;
    public Button exit;
    public Button home;
    public Text distanceText;
    public Text distance;
    public Text timeText;
    public Text time;

    
    // Use this for initialization
    void Start () {
        menu = menu.GetComponent<Canvas>();
        play = play.GetComponent<Button>();

        if(Application.loadedLevelName == "Play")
        {
            menu.enabled = false;
            home = home.GetComponent<Button>();
            distanceText = distanceText.GetComponent<Text>();
            distance = distance.GetComponent<Text>();
            timeText = timeText.GetComponent<Text>();
            time = time.GetComponent<Text>();
        
        }
        else
        {
            exit = exit.GetComponent<Button>();
            menu.enabled = true;
        }
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
}
