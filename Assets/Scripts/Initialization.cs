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
                text.transform.localScale = new Vector2(
                    text.transform.localScale.x + 1,
                    text.transform.localScale.y + 1);

                text.verticalOverflow = VerticalWrapMode.Overflow;
                text.horizontalOverflow = HorizontalWrapMode.Overflow;
            }

            foreach (Button button in buttons)
            {
                button.transform.localScale = new Vector2(
                    button.transform.localScale.x + 1,
                    button.transform.localScale.y + 1);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
