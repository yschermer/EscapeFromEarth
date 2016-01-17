using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class Player : MonoBehaviour
{
    private float cameraLimitRight = 3.5f;
    private float cameraLimitLeft = -3.5f;

    private Vector2 fingerStart;
    private Vector2 fingerEnd;

    public enum Movement
    {
        Left,
        Right
    }

    void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            cameraLimitRight = 1.5f;
            cameraLimitLeft = -1.5f;
        }
        

        // gameObject
        float x = 0;
        float y = -2;
        float z = 0;
        this.gameObject.transform.position = new Vector3(x, y, z);
    }
    public List<Movement> movements = new List<Movement>();


    // Update is called once per frame
    void Update()
    {
        float distance = 0.15f;

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


        //Touch
        foreach (Touch touch in Input.touches)
        {

            if (touch.phase == TouchPhase.Began)
            {
                fingerStart = touch.position;
                fingerEnd = touch.position;
            }

            if (touch.phase == TouchPhase.Moved)
            {
                fingerEnd = touch.position;

                //There is more movement on the X axis than the Y axis
                if (Mathf.Abs(fingerStart.x - fingerEnd.x) > Mathf.Abs(fingerStart.y - fingerEnd.y))
                {

                    //Right Swipe
                    if ((fingerEnd.x - fingerStart.x) > 0)
                    {
                        if (this.gameObject.transform.position.x < cameraLimitRight)
                        {
                            this.gameObject.transform.position = new Vector2((this.gameObject.transform.position.x + distance), this.gameObject.transform.position.y);
                        }
                        movements.Add(Movement.Right);
                    }
                    else
                    {
                        //Left Swipe
                        if (this.gameObject.transform.position.x > cameraLimitLeft)
                        {
                            this.gameObject.transform.position = new Vector2((this.gameObject.transform.position.x - distance), this.gameObject.transform.position.y);
                        }
                        movements.Add(Movement.Left);
                    }
                }

                ////More movement along the Y axis than the X axis
                //else {
                //    //Upward Swipe
                //    if ((fingerEnd.y - fingerStart.y) > 0)
                //        movements.Add(Movement.Up);
                //    //Downward Swipe
                //    else
                //        movements.Add(Movement.Down);
                //}


                //After the checks are performed, set the fingerStart & fingerEnd to be the same
                fingerStart = touch.position;

                //Now let's check if the Movement pattern is what we want
                //In this example, I'm checking whether the pattern is Left, then Right, then Left again
                Debug.Log(CheckForPatternMove(0, 3, new List<Movement>() { Movement.Left, Movement.Right, Movement.Left }));
            }


            if (touch.phase == TouchPhase.Ended)
            {
                fingerStart = Vector2.zero;
                fingerEnd = Vector2.zero;
                movements.Clear();
            }
        }
    }
    private bool CheckForPatternMove(int startIndex, int lengthOfPattern, List<Movement> movementToCheck)
    {

        //If the currently stored movements are fewer than the length of the pattern to be detected
        //it can never match the pattern. So, let's get out
        if (lengthOfPattern > movements.Count)
            return false;

        //In case the start index for the check plus the length of the pattern
        //exceeds the movement list's count, it'll throw an exception, so lets get out
        if (startIndex + lengthOfPattern > movements.Count)
            return false;

        //Populate a temporary list with the respective elements
        //from the movement list
        List<Movement> tMovements = new List<Movement>();
        for (int i = startIndex; i < startIndex + lengthOfPattern; i++)
            tMovements.Add(movements[i]);

        //Now check whether the sequence of movements is the same as the pattern you want to check for
        //The SequenceEqual method is in the System.Linq namespace
        return tMovements.SequenceEqual(movementToCheck);
    }
    // Die by collision
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            Die();
        }
        else if (other.gameObject.tag == "Sunlight")
        {
            Destroy(other.gameObject);
            // Punten verdienen
        }
    }

    void Die()
    {
        Application.LoadLevel("Play");
    }
}
