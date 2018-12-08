using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMovement : MonoBehaviour {

	private readonly Vector3 _oneShaftUp = new Vector3(0,1.35f,0);
	private readonly Vector3 _oneShaftDown = new Vector3(0,-1.35f,0);

	[SerializeField] private PlayerMovement _playerState;
	
	// Update is called once per frame
	void Update () {

		if (_playerState.CurrentState == PlayerMovement.State.Elevator)
		{
			if(Input.GetKeyDown(KeyCode.UpArrow))
			{
				if (ProductionController.Instance.GetShaftCount()-1> ProductionController.Instance.CurrentShaftNummer)
				{
					transform.Translate(_oneShaftUp);
					ProductionController.Instance.CurrentShaftNummer++;
				}
			}

			if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				if ( ProductionController.Instance.CurrentShaftNummer > 0)
				{
					transform.Translate(_oneShaftDown);
					ProductionController.Instance.CurrentShaftNummer--;
				}
			}
		}		
	}
}

