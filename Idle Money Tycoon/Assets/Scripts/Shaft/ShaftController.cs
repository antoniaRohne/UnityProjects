using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using UnityEngine.Analytics;

public class ShaftController : MonoBehaviour
{
	private Shaft _shaft;

	[SerializeField] public ShaftView Shaftview;

	public float CurrentManagerFactor;

	public Shaft CreateShaft(int shaftNummer)
	{
		_shaft = new Shaft(shaftNummer,500);
		UpdateView();
		return _shaft;
	}
	
	public void SetShaft(Shaft shaft)
	{
		_shaft = shaft;
		if (!_shaft.Locked)
		{
			Shaftview.Unlock();
			StartCoroutine(ProduceMoney());
		}
		UpdateView();
	}
	
	private void _lvlUp()
	{
		_shaft.Lvl++;
		_shaft.Costs += _shaft.Costs;
		_shaft.Income = _shaft.Income * 2;
		UpdateView();
		ProductionController.Instance.IdleCalculator.UpdateIdleCash(_shaft.Income);
	}

	private void OnTriggerStay2D(Collider2D other)
	{
 		if (Input.GetKeyDown(KeyCode.Space))
		 {
			 UpdateShaft();
		 }
	}

	private void UpdateShaft()
	{
		if (ProductionController.Instance.MoneyController.PayMoney(_shaft.Costs))
		{
			if (_shaft.Locked)
				Unlock();
			else
				_lvlUp();
		}
	}

	private void Unlock()
	{
		_shaft.Lvl = 1;
		_shaft.Costs = 200;
		_shaft.Income = 50;
		_shaft.ProducingTime = 5;
		_shaft.Locked = false;
		Shaftview.Unlock();
		StartCoroutine(ProduceMoney());
		ProductionController.Instance.UnlockNewShaft();
		UpdateView();
	}

	private void UpdateView()
	{
		Shaftview.SetLvl(_shaft.Lvl);
		Shaftview.SetNextCosts(_shaft.Costs);
	}

	IEnumerator ProduceMoney()
	{
		while (true)
		{
			yield return new WaitForSeconds(_shaft.ProducingTime);
			ProductionController.Instance.MoneyController.AddMoney(_shaft.Income*_shaft.ProducingTime, CurrentManagerFactor);
			Shaftview.ShowEarnedCash(_shaft.Income*_shaft.ProducingTime);
		}
	}
}
