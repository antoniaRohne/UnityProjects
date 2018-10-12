using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour {

	public float backgroundSize;
	public float parallaxSpeed;
	[SerializeField]
	public Camera camera;
	private Transform[] layers;
	private int viewZone = 2;
	private int leftIndex;
	private int rightIndex;
	private float lastCameraX;

	private void Start(){

		lastCameraX = camera.transform.position.x;

		layers = new Transform[transform.childCount];
		for(int i =0; i<transform.childCount;i++){
			layers[i] = transform.GetChild(i);
		}

		leftIndex = 0;
		rightIndex = layers.Length-1;
	}

	private void Update(){

		float deltaX = camera.transform.position.x - lastCameraX;
		transform.position += Vector3.right *(deltaX*parallaxSpeed);
		lastCameraX = camera.transform.position.x;

		if(camera.transform.position.x < layers[leftIndex].transform.position.x+viewZone){
			ScrollLeft();
		}
		if(camera.transform.position.x > layers[rightIndex].transform.position.x-viewZone){
			ScrollRight();
		}
	}

	private void ScrollLeft(){
		layers[rightIndex].position = new Vector3((layers[leftIndex].position.x-backgroundSize),layers[leftIndex].position.y,0);
		leftIndex = rightIndex;
		rightIndex--;
		if(rightIndex<0){
			rightIndex = layers.Length-1;
		}
	}

	private void ScrollRight(){
		layers[leftIndex].position = new Vector3((layers[rightIndex].position.x+backgroundSize),layers[leftIndex].position.y,0);
		rightIndex = leftIndex;
		leftIndex++;
		if(leftIndex== layers.Length){
			leftIndex = 0;
		}
	}
}
