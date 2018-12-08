using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class MoneyController
{
	private double _money = 0;
	private readonly MoneyView _moneyView;

	private readonly BoostController _boostController;

	public MoneyController(MoneyView mv, BoostController boostController)
	{
		_moneyView = mv;
		_boostController = boostController;
	}

	public void AddMoney(double value, float managerFactor)
	{
		double boost = _boostController.CurrentBoostFactor.Value + managerFactor;

		if (boost > 0)
			_money += value * boost * ProductionController.Instance.PrestigeFactor;
		else
			_money += value * ProductionController.Instance.PrestigeFactor;
		
		_moneyView.SetMoneyValue(_money);
	}

	public void AddMoney(double value)
	{
		_money += value;
		_moneyView.SetMoneyValue(_money);
	}
	
	public bool PayMoney(double value)
	{
		if (CheckForEnoughMoney(value))
		{
			_money -= value;
			_moneyView.SetMoneyValue(_money);
			return true;
		}

		return false;

	}

	private bool CheckForEnoughMoney(double costs)
	{
		return _money >= costs;
	}

	public double GetMoney()
	{
		return _money;
	}
	
}
