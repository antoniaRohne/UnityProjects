using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    float speed = 3f;
    [SerializeField]
    GameObject player;

    private void Awake()
    {
        player = GameObject.Find("Player(Clone)");
    }

    private void Update()
    {
        Vector3 direction = player.transform.position - transform.position;

        transform.position += direction.normalized * speed * Time.deltaTime;
    }
}
