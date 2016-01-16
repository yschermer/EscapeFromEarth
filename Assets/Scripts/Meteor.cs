using UnityEngine;
using System.Collections;

public class Meteor : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        float minPosition = -3.5f;
        float maxPosition = 3.5f;

        gameObject.transform.position = new Vector2(Random.Range(minPosition, maxPosition), 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.position.y < -4)
        {
            DestroyObject(this.gameObject);
        }
    }
}
