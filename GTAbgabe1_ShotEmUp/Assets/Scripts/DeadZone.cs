using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("bullet"))
            Destroy(other.gameObject);
    }
}
