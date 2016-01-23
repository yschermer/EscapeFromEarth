using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetUserName : MonoBehaviour {

    public InputField textField;
    public static string newUsername;
    public static bool submitted;

    // Use this for initialization
    void Start () {
        textField = textField.GetComponent<InputField>();
        submitted = false;
    }

    public void Submit()
    {
        if (!string.IsNullOrEmpty(textField.text))
        {
            newUsername = textField.text;
            OnSubmit(true);
            print("submittrue");
            Application.LoadLevel("Highscores");
        }
        OnSubmit(false);
    }

    public static void OnSubmit(bool submit)
    {
        submitted = submit;
    }

}
