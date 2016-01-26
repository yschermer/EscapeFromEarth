using UnityEngine;
using System.Collections;

public class Meteor : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        gameObject.transform.position = new Vector2(Random.Range(Initialization.minPositionX, Initialization.maxPositionX), 5);
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
