using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopView : MonoBehaviour {

	[SerializeField] private GameObject _shopPanel;
	[SerializeField] private ShopEntryView _shopEntry;
	private Button _firstButton;

	public void CloseShopPanel()
	{
		_shopPanel.gameObject.SetActive(false);
	}

	public void ShowShopPanel()
	{
		_shopPanel.gameObject.SetActive(true);
		_firstButton.Select();
	}

	public Dictionary<Boost, Button> PrepareShopEntriesAndButtons(List<Boost> boosts)
	{
		Dictionary<Boost,Button> buttons = new Dictionary<Boost, Button>();
		foreach (Boost b in boosts)
		{
			ShopEntryView shopEntry = Instantiate(_shopEntry, this.gameObject.transform);
			shopEntry.CostsDisplay.text = b.Costs.ToString();
			shopEntry.SetDurationDisplay(b.Duration);
			shopEntry.SetFactorDisplay(b.Factor);
			shopEntry.Icon.sprite = b.Icon;
			buttons.Add(b,shopEntry.GetButton());
		}

		buttons.TryGetValue(boosts[0], out _firstButton);

		return buttons;
	}
}
