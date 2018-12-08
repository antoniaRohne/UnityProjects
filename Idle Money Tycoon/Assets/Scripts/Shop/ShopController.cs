using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class ShopController
{
	public readonly ShopView ShopView;

	public ShopController(List<Boost> boostEntries, ShopView shopView)
	{
		ShopView = shopView;
		
		Dictionary<Boost,Button> buttons = shopView.PrepareShopEntriesAndButtons(boostEntries);
		
		foreach (KeyValuePair<Boost,Button> keyValuePair in buttons)
		{
			keyValuePair.Value.onClick.AsObservable().Subscribe(x => BuyBoost(keyValuePair.Key));
		}
	}

	private void BuyBoost(Boost boost)
	{
		if (ProductionController.Instance.MoneyController.PayMoney(boost.Costs))
		{
			ProductionController.Instance.BoostController.AddBoost(boost);
		}
	}
}
