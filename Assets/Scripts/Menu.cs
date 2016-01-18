using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    public Canvas menu;
    public Button play;
    public Button exit;

	// Use this for initialization
	void Start () {
        menu = menu.GetComponent<Canvas>();
        play = play.GetComponent<Button>();
        exit = exit.GetComponent<Button>();

        menu.enabled = true;
    }
	
    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        menu.enabled = false;
        Application.LoadLevel("Play");
    }
}
