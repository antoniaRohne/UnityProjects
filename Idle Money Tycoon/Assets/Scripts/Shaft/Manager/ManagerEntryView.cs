using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerEntryView : MonoBehaviour
{
	[SerializeField] public Button BuyButton;
	[SerializeField] public Text CostsDisplay;
	[SerializeField] public Text FactorDisplay;
	[SerializeField] public Image Icon;
	
	public void SetFactorDisplay(float factor)
	{
		FactorDisplay.text = factor + "x";
	}
}
