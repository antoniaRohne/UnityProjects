using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.UI;

public class IdleCalculator : MonoBehaviour
{

	[SerializeField] private IdlePanelView _idlePanelView;
	[SerializeField] private GameObject _canvas;
	[SerializeField] private Text _idleDisplay;
	
	private double _idleCashPerSecond = 0;
	private double _idleDivider = 10;
	private double _totalIncome;


	public void CalculateEarnedIdleCash(List<Shaft> shafts)
	{
		SetIdleCashPerSecond(shafts);

		if (PlayerPrefs.HasKey("oldDateTime")&& _idleCashPerSecond>0)
		{
			DateTime currentDate = System.DateTime.Now;

			long temp = Convert.ToInt64(PlayerPrefs.GetString("oldDateTime"));
		
			DateTime oldDate = DateTime.FromBinary(temp);
 
			TimeSpan difference = currentDate - oldDate;
			
			IdlePanelView idleCash = Instantiate(_idlePanelView, _canvas.transform);
			idleCash.SetTime(difference);
			idleCash.SetMoney(CalculateProducedCash(difference.TotalSeconds));
			UpdateView();
		}
	}

	private void SetIdleCashPerSecond(List<Shaft> shafts)
	{
		_totalIncome = CalculateTotalIncomePerSecond(shafts);
		if (_totalIncome > 0)
			_idleCashPerSecond = _totalIncome / _idleDivider;
	}

	private double CalculateTotalIncomePerSecond(List<Shaft> shafts)
	{
		double totalIncome = 0;
		foreach (var s in shafts)
		{
			Debug.Log(s.Income);
			if(!s.Locked)
				totalIncome += s.Income;
		}
		return totalIncome;
	}
	
	void OnApplicationQuit()
	{
		PlayerPrefs.SetString("oldDateTime", System.DateTime.Now.ToBinary().ToString());
	}

	private double CalculateProducedCash(double seconds)
	{
		return _idleCashPerSecond* Math.Floor(seconds);
	}

	private void UpdateView()
	{
		_idleDisplay.text = _idleCashPerSecond+"/s";
	}

	public void UpdateIdleCash(double value)
	{
		_idleCashPerSecond = (_totalIncome + value) / _idleDivider;
		UpdateView();
	}

}
