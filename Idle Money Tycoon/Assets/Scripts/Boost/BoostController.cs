using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class BoostController
{
	private readonly List<Boost> _activeBoosts = new List<Boost>();
	private BoostView _boostView;

	public readonly ReactiveProperty<float> CurrentBoostFactor = new ReactiveProperty<float>();

	public BoostController(BoostView boostView)
	{
		_boostView = boostView;
	}
	
	public void AddBoost(Boost boost)
	{
		_activeBoosts.Add(boost);	
		CalculateCurrentBoostFactor();
		Observable.Timer(TimeSpan.FromSeconds(boost.Duration)).Subscribe(_ => RemoveBoost(boost));
	}

	private void CalculateCurrentBoostFactor()
	{
		float factor = 0;
		foreach (Boost boost in _activeBoosts)
		{
			factor += boost.Factor;
		}
		CurrentBoostFactor.Value = factor;
	}

	private void RemoveBoost(Boost boost)
	{
		_activeBoosts.Remove(boost); 
		CalculateCurrentBoostFactor();
	}

}
