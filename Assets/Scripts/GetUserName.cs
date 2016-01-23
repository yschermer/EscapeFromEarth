using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetUserName : MonoBehaviour {

    public static InputField textField;
    // Use this for initialization
    void Start () {
        textField = textField.GetComponent<InputField>();
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
