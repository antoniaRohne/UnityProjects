using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPackBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(waitAndDestroy());
	}
	
	void OnTriggerEnter(Collider collider){
		if(collider.gameObject.tag == "Player"){
			GameController.instance.addAmmo();
			Destroy(gameObject);
		}
	}

	IEnumerator waitAndDestroy(){
		yield return new WaitForSecondsRealtime(2.4f);

		Destroy(gameObject);
	}
}
