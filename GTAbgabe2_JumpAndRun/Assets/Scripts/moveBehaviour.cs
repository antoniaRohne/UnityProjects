using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBehaviour : MonoBehaviour {

    groundCheck groundCheck;

    [SerializeField]
    float speed = 0.5f;
    float moveSpeed;
    [SerializeField]
    float jumpForce;

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator a;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        a = GetComponent<Animator>();
        groundCheck = GetComponentInChildren<groundCheck>();
    }
   
        private void FixedUpdate()
        {
            a.SetFloat("velocity-y", rb.velocity.y);

            float moveHorizontal = Input.GetAxisRaw("Horizontal");
            float moveVertical = 0;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(groundCheck.grounded)
                moveVertical = jumpForce;
            }

            if (moveHorizontal < 0)
                sr.flipX = true;
            else if (moveHorizontal > 0)
                sr.flipX = false;

            Vector2 movement = new Vector2(moveHorizontal,moveVertical);

            moveSpeed= Mathf.Abs(rb.velocity.x);

            a.SetFloat("movement", moveSpeed);

            rb.AddForce(movement*speed, ForceMode2D.Force);

        }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "Enemy")
        a.SetTrigger("isHit");
    }

}
