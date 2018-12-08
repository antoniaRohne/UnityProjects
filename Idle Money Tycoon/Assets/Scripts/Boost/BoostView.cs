using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class BoostView : MonoBehaviour {

	[SerializeField] private Text _boostFactor;

	private void Start()
	{
		ProductionController.Instance.BoostController.CurrentBoostFactor.Subscribe(x => _boostFactor.text = x.ToString()).AddTo(this);
	}
	
}
