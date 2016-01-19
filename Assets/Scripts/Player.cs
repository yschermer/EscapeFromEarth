using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class Player : TouchSprite
{
    private float cameraLimitRight = 3.5f;
    private float cameraLimitLeft = -3.5f;
    private bool flag = false;
    public float speed = 0.02f;

    float distance = 0.15f;

    void Start()
    {
        // gameObject
        float x = 0;
        float y = -2;
        float z = 0;
        this.gameObject.transform.position = new Vector3(x, y, z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
        {
            distance = 0;
        }
        else
        {
            distance = 0.15f;
        }

        // Jump keyboard
        if (Input.GetKey("left"))
        {
            if (this.gameObject.transform.position.x > cameraLimitLeft)
            {
                this.gameObject.transform.position = new Vector2((this.gameObject.transform.position.x - distance), this.gameObject.transform.position.y);
            }
        }
        else if (Input.GetKey("right"))
        {
            if (this.gameObject.transform.position.x < cameraLimitRight)
            {
                this.gameObject.transform.position = new Vector2((this.gameObject.transform.position.x + distance), this.gameObject.transform.position.y);
            }
        }
        TouchInput(GetComponent<BoxCollider2D>());


    }

    void OnFirstTouch()
    {
        Vector3 pos;
        if(Time.timeScale == 1)
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
}
