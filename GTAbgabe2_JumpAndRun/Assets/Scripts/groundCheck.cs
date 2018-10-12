using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCheck : MonoBehaviour {

    Animator a;
    public bool grounded;
    Rigidbody2D rb;

    private void Start()
    {
       a = GetComponentInParent<Animator>();
       rb = GetComponentInParent<Rigidbody2D>();
        grounded = true;
        a.SetBool("grounded", true);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        a.SetBool("grounded", true);
        grounded = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //rb.velocity = new Vector2(0, 0);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        a.SetBool("grounded", false);
        grounded = false;
    }
}
