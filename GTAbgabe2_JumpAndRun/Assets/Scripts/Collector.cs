using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour {

	string name;

	void setName(string name){
		this.name = name;
	}

	void OnTriggerEnter2D (Collider2D col){
		Debug.Log("collected");
		GameController.instance.collected();
		Destroy(this.gameObject);
	}
}
