﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class Player : TouchSprite
{
    public static float speed;
    public static float x;
    public static float y;
    public static float z;
    int count;

    void Start()
    {
        gameObject.transform.position = new Vector3(x, y, z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
        {
            speed = 0;
        }
        else
        {
            speed = 0.15f;
        }

        // Jump keyboard
        if (Input.GetKey("left"))
        {
            if (this.gameObject.transform.position.x > Initialization.minPositionX)
            {
                this.gameObject.transform.position = new Vector2((this.gameObject.transform.position.x - speed), this.gameObject.transform.position.y);
            }
        }
        else if (Input.GetKey("right"))
        {
            if (this.gameObject.transform.position.x < Initialization.maxPositionX)
            {
                this.gameObject.transform.position = new Vector2((this.gameObject.transform.position.x + speed), this.gameObject.transform.position.y);
            }
        }

        //Touch
        TouchInput(GetComponent<BoxCollider2D>());

        //Back button on phones function
#if UNITY_ANDROID
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            count = 1;
        }
#endif

        Canvas[] menus = FindObjectsOfType<Canvas>();

        foreach (Canvas menu in menus)
        {
            if (menu.name == "Score")
            {

                //save and set scores https://www.youtube.com/watch?v=1ZGDBuJjFbY


                //save and set personal scores
                if (PlayerPrefs.GetInt("personalScore").ToString() == null)
                {
                    //Save personal score

                }
                else
                {
                    //Read exist personal score

                }
            }
        }
    }

#if UNITY_ANDROID
    void OnApplicationPause()
    {
        Time.timeScale = 0;
        count = 1;
    }

    void OnGUI()
    {
        if (count == 1)
        {
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "Exit");
            GUI.Label(new Rect(Screen.width * 1 / 4, Screen.height * 2 / 6, Screen.width * 2 / 4, Screen.height * 1 / 6), "Are you sure you want to exit the game?");
            if (GUI.Button(new Rect(Screen.width / 4, Screen.height * 3 / 8, Screen.width / 2, Screen.height / 8), "Yes"))
            {

                Application.Quit();

            }
            if (GUI.Button(new Rect(Screen.width / 4, Screen.height * 4 / 8, Screen.width / 2, Screen.height / 8), "Keep Playing"))
            {
                count = 0;
                Time.timeScale = 1;
            }
        }
    }
#endif

    void OnFirstTouch()
    {
        Vector3 pos;
        if (Time.timeScale == 1)
        {
            pos = new Vector3(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).x, transform.position.y, transform.position.z);
            transform.position = pos;
        }
    }

    // Die by collision
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            Die();
        }
    }

    void Die()
    {
        Time.timeScale = 0;
        Canvas[] menus = FindObjectsOfType<Canvas>();

        UpdateHighscore();

        foreach (Canvas menu in menus)
        {
            if (menu.name == "Menu")
            {
                menu.enabled = true;
            }
            else if (menu.name == "Score")
            {
                menu.enabled = false;
            }
        }
    }

    public void UpdateHighscore()
    {
        if (PlayerPrefs.HasKey("User"))
        {
            HighScores.AddNewHighscore(PlayerPrefs.GetString("User"), Score.distance);
        }
    }
}
