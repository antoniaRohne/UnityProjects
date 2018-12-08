using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCollision : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        GameController.instance.endGame();
    }
}
