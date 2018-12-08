using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour{

    private Vector3 start;
    private Vector3 move;
    public float shift;
    public float speed = 2;

    // Use this for initialization
    void Start()
    {
        start = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        move = start;
        move.x = move.x + Mathf.PingPong(Time.time * speed, shift) - 1;

        transform.position = move;

    }


}