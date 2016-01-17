using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Diagnostics;

public class Time : MonoBehaviour
{
    Text textComponent;
    Stopwatch timer;

    // Use this for initialization
    void Start()
    {
        textComponent = GetComponent<Text>();
        timer = new Stopwatch();
        timer.Start();
    }

    // Update is called once per frame
    void Update()
    {
        textComponent.text = string.Format("Time: {0} seconds", timer.Elapsed.Seconds);
    }
}
