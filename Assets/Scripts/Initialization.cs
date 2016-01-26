using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Initialization : MonoBehaviour {

    public static float maxPositionX;
    public static float minPositionX;

    // Use this for initialization
    void Start () {
        SetPlatformSpecificSettings();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    
    private void SetPlatformSpecificSettings()
    {
        Player.speed = 0.15f;
        Player.x = 0;
        Player.y = -2;
        Player.z = 0;
        switch (Application.platform)
        {
            case RuntimePlatform.Android:
                maxPositionX = 1.4f;
                minPositionX = -1.4f;
                break;
            case RuntimePlatform.IPhonePlayer:
                maxPositionX = 1.4f;
                minPositionX = -1.4f;
                break;
            case RuntimePlatform.WindowsPlayer:
                maxPositionX = 1.4f;
                minPositionX = -1.4f;
                break;
            default:
                print(Application.platform);
                maxPositionX = 1.4f;
                minPositionX = -1.4f;
                break;
        }
    }
}
