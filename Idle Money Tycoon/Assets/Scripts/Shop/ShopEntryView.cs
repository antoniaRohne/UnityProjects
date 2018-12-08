using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class ShopEntryView : MonoBehaviour
{
	[SerializeField] public Button BuyButton;
	[SerializeField] public Text CostsDisplay;
	[SerializeField] public Text DurationDisplay;
	[SerializeField] public Text FactorDisplay;
	[SerializeField] public Image Icon;

	public void SetDurationDisplay(float duration)
	{
		DurationDisplay.text = duration + "s";
	}
	
	public void SetFactorDisplay(float factor)
	{
		FactorDisplay.text = factor + "x";
	}

	public Button GetButton()
	{
		return BuyButton;
	}
}
