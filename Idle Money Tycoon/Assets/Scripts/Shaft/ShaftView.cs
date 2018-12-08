using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShaftView : MonoBehaviour
{

	[SerializeField] private TextMesh _lvl;
	[SerializeField] private TextMesh _nextCosts;
	[SerializeField] private TextMesh _earnedCash;
	[SerializeField] private SpriteRenderer _managerSprite;

	[SerializeField] private GameObject _lvlBox;
	[SerializeField] private GameObject _lock;
	[SerializeField] private GameObject _manager;
	

	public void SetManagerSprite(Sprite managerSprite)
	{
		_managerSprite.sprite = managerSprite;
	}
	
	public void SetLvl(double value)
	{
		_lvl.text = value.ToString();
	}
	
	public void SetNextCosts(double value)
	{
		_nextCosts.text = value.ToString();
	}

	public void ShowEarnedCash(double value)
	{
		_earnedCash.text = value.ToString();
		TextMesh show = Instantiate(_earnedCash, this.transform);
		Destroy(show.gameObject, 3.0f);
	}

	public void Unlock()
	{
		_lvlBox.SetActive(true);
		_manager.SetActive(true);
		_lock.SetActive(false);
	}
}
