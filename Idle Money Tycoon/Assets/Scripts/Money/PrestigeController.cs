using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;
using UnityEngine.UI;

public class PrestigeView: MonoBehaviour
{
	[SerializeField] private Text _factor;

	public void SetFactor(float factor)
	{
		_factor.text = factor.ToString();
	}
}
