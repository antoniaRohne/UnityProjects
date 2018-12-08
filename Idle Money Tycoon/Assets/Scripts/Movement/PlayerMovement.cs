using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UniRx;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private Transform _elevatorTransform;
	[SerializeField] private Transform _groundLeftTransform;

	public enum State
	{
		Chest,
		Elevator,
		Shaft, 
		Shop,
		ManagerPanel
	};

	public State CurrentState = State.Chest;

	void Update () {

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
	        switch (CurrentState)
	        {
		        case State.Chest: 
			        transform.position = _elevatorTransform.position;
			        transform.position += new Vector3(0,0.3f,0);
			        transform.parent = _elevatorTransform;
			        CurrentState = State.Elevator;
			        break;
		        case State.Elevator:
			        if ( ProductionController.Instance.CurrentShaftNummer >= 0)
			        {
						transform.position += new Vector3(1.2f, 0, 0);
				        transform.parent = null;
				        CurrentState = State.Shaft;
			        }
					break;
		        case State.Shaft:
			        CurrentState = State.ManagerPanel;
			        ProductionController.Instance.ManagerController.ManagerView.ShowManagerPanel(); 
			        break;
		        case State.Shop:
			        CurrentState = State.Chest;
			        ProductionController.Instance.ShopController.ShopView.CloseShopPanel();
			        break;
	        }
        }
		
		if(Input.GetKeyDown(KeyCode.LeftArrow))
		{
			switch (CurrentState)
			{
				case State.Elevator: 
					if( ProductionController.Instance.CurrentShaftNummer ==0){
					transform.position = _groundLeftTransform.position;
					transform.position+= new Vector3(0.3f, 0.8f, 0);
					transform.parent = null;
					CurrentState = State.Chest;
					}
					break;
				case State.Shaft:
					transform.position = _elevatorTransform.position;
					transform.position += new Vector3(0,0.3f,0);
					transform.parent = _elevatorTransform;
					CurrentState = State.Elevator;
					break;
				case State.Chest:
					CurrentState = State.Shop;
					ProductionController.Instance.ShopController.ShopView.ShowShopPanel(); 
					break;
				case State.ManagerPanel:
					CurrentState = State.Shaft;
					ProductionController.Instance.ManagerController.ManagerView.CloseManagerPanel();
					break;
			}
		}
		

		
	}
}
