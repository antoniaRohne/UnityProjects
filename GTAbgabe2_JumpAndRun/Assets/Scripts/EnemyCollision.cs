using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour {

    Animator a;
    Animation anim;

    void Start()
    {
        a = GetComponent<Animator>();
        anim = GetComponent<Animation>(); 
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameController.instance.hit();
        }
      
    }

}
