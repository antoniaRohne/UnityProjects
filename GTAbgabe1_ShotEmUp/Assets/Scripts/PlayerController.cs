using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    float speed;
    [SerializeField]
    BulletInstantiater bulletInst;
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            bulletInst.InstantiateBullet();
        }

    }

    private void FixedUpdate()
    {

        if (Input.GetKey("w"))
        {
            this.transform.position += new Vector3(0f, speed * Time.deltaTime, 0f);
        }
        if (Input.GetKey("s"))
        {
            this.transform.position += new Vector3(0f, -speed * Time.deltaTime, 0f);
        }
        if (Input.GetKey("a"))
        {
            this.transform.position += new Vector3(-speed * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey("d"))
        {
            this.transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
        }
    }
}
