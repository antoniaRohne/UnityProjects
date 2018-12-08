using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyView : MonoBehaviour
{
	[SerializeField] private Text _moneyValue;

	public void SetMoneyValue(double value)
	{
		_moneyValue.text = value.ToString("F0");
	}
}
