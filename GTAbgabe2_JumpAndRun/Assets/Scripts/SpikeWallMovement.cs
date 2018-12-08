using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeWallMovement : MonoBehaviour {


    private Vector3 start;
    private Vector3 move;
    public float shift;
    public float speed = 2;
    private int counter;

    // Use this for initialization
    void Start()
    {
        start = transform.position;
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {

        move = start;
        move.y = move.y + Mathf.PingPong(Time.time * speed, shift) - 1;

        transform.position = move;

    }
}
