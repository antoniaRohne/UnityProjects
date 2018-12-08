using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject Player;       //Public variable to store a reference to the player game object
	private readonly Vector3 _offset = new Vector3(0,1.2f,0);
    
	void LateUpdate () 
	{
		Vector3 tempVec3;
		tempVec3.x = this.transform.position.x;
		tempVec3.y = Player.transform.position.y;
		tempVec3.z = this.transform.position.z;
		this.transform.position = tempVec3;
		transform.position += _offset;
	}
}