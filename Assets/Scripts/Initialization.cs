using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Initialization : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    if(Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            Text[] texts = FindObjectsOfType<Text>();
            Button[] buttons = FindObjectsOfType<Button>();

            foreach (Text text in texts)
            {
          
            }

            foreach (Button button in buttons)
            {
                
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
