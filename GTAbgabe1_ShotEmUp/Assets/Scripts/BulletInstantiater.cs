using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletInstantiater : MonoBehaviour {

    [SerializeField]
    GameObject bullet;

    public void InstantiateBullet()
    {
        if (GameController.instance.ammo > 0)
        {
            GameObject bull = Instantiate(bullet);
            bull.transform.position = transform.position;
            GameController.instance.ammo--;
        }
    }
	
}
