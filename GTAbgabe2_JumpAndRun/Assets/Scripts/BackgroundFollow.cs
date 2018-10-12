using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFollow : MonoBehaviour {

    [SerializeField]
    Camera cam;
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(cam.transform.position.x,cam.transform.position.y, cam.transform.position.z+10);
	}
}
