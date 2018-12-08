using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ManagerView : MonoBehaviour
{

	[SerializeField] private ManagerEntryView _managerEntryView;
	[SerializeField] private GameObject _panelTransform;
	private Button _firstButton;

	public void CloseManagerPanel()
	{
		this.gameObject.SetActive(false);
	}

	public void ShowManagerPanel()
	{
		this.gameObject.SetActive(true);
		_firstButton.Select();
	}
	
	public Dictionary<Manager, Button> PrepareManagerEntriesAndButtons(List<Manager> managers)
	{
		Dictionary<Manager,Button> buttons = new Dictionary<Manager, Button>();
		foreach (Manager m in managers)
		{
			ManagerEntryView managerEntryView = Instantiate(_managerEntryView, _panelTransform.transform);
			managerEntryView.CostsDisplay.text = m.Costs.ToString();
			managerEntryView.SetFactorDisplay(m.Factor);
			managerEntryView.Icon.sprite = m.ManagerSprite;
			buttons.Add(m,managerEntryView.BuyButton);
		}
		
		buttons.TryGetValue(managers[0], out _firstButton);

		return buttons;
	}

}
