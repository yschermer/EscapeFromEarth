using UnityEngine;
using System.Collections;

public class Animate : MonoBehaviour {

    private Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Boost", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (animator.GetBool("Boost"))
            {
                animator.SetBool("Boost", false);
            }
            else
            {
                animator.SetBool("Boost", true);
            }
        }
    }
}
