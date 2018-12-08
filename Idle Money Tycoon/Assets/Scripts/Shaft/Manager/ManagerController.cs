using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class ManagerController
{
	public readonly ManagerView ManagerView;
	private ManagerView _managerPanel;
	
	public float CurrentManagerFactor = 0;

	public ManagerController(List<Manager> managerEntries, ManagerView managerView)
	{
		ManagerView = managerView;
		
		Dictionary<Manager,Button> buttons = ManagerView.PrepareManagerEntriesAndButtons(managerEntries);
		
		foreach (KeyValuePair<Manager,Button> keyValuePair in buttons)
		{
			keyValuePair.Value.onClick.AsObservable().Subscribe(x => BuyManager(keyValuePair.Key));
		}
	}

	private void BuyManager(Manager manager)
	{
		if (ProductionController.Instance.MoneyController.PayMoney(manager.Costs))
		{
			ProductionController.Instance.GetCurrentShaftController().Shaftview.SetManagerSprite(manager.ManagerSprite);
			ProductionController.Instance.GetCurrentShaftController().CurrentManagerFactor = manager.Factor;
		}
	}
}
