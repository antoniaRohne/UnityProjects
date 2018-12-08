using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using UniRx;
using UnityEngine;

public class ProductionController : MonoBehaviour
{
	
	public static ProductionController Instance = null;
	
	[SerializeField] private ShaftController _shaftObject;
	[SerializeField] private GameObject _shaftsTransform;
	private readonly Vector3 _offset = new Vector3(0,1.35f,0);

	private readonly List<ShaftController> _listOfShaftObjects = new List<ShaftController>();
	[SerializeField] private GameObject _shaftList;
	
	private GameData _gameData;
	private string gameDataFilepath = "Savegame.json";
	[SerializeField] private bool _useClearSavegame;

	[SerializeField] public IdleCalculator IdleCalculator;
	
	public MoneyController MoneyController;
	[SerializeField] private MoneyView _moneyView;
	
	public BoostController BoostController;
	[SerializeField] private BoostView _boostView;
	
	public ManagerController ManagerController;
	[SerializeField] private ManagerView _managerView;
	
	public ShopController ShopController;
	[SerializeField] private ShopView _shopView;	
	[SerializeField] private List<Boost> _listOfBoosts;
	
	[SerializeField] private List<Manager> _listOfManagers;

	public int CurrentShaftNummer;
	
	private int _nextShaftNummer = 0;
	

	public float PrestigeFactor = 1;

	void Awake()
	{
		if (Instance == null)
			Instance = this;
		else if (Instance != this)
			Destroy(gameObject);
		DontDestroyOnLoad(gameObject);

		BoostController = new BoostController(_boostView);
		MoneyController = new MoneyController(_moneyView, BoostController);
		ShopController = new ShopController(_listOfBoosts, _shopView);
		ManagerController = new ManagerController(_listOfManagers,_managerView);
		
		if (_useClearSavegame)
		PlayerPrefs.SetFloat("money", 3000);	
		
		float oldMoney = PlayerPrefs.GetFloat("money"); 
		MoneyController.AddMoney(oldMoney);
	}

	private void Start()
	{
		_gameData = new GameData();
		if (!_useClearSavegame)
		{
			string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFilepath);
			if (File.Exists(filePath))
			{
				_gameData = (GameData) JsonConvert.DeserializeObject(File.ReadAllText(filePath), typeof(GameData));
			}
			IdleCalculator.CalculateEarnedIdleCash(_gameData.Shafts);
		}
		
		SetupSavegame();
	}

	private void FixedUpdate()
	{
		if (Input.GetKeyUp(KeyCode.P))
		{
			if (MoneyController.GetMoney() > 20000 && _gameData.Shafts.Count > 4)
			{
				Prestige();
			}
		}
	}

	public void UnlockNewShaft()
	{
		ShaftController newShaft = Instantiate(_shaftObject, _shaftsTransform.transform);
		newShaft.transform.position += _offset*_gameData.Shafts.Count;
		_listOfShaftObjects.Add(newShaft);
		_gameData.Shafts.Add(newShaft.CreateShaft(_nextShaftNummer));
		_nextShaftNummer++;
	}

	private void SetupSavegame()
	{
		if(_gameData.Shafts.Count==0)
			UnlockNewShaft();
		else
		{
			foreach (var shaft in _gameData.Shafts)
			{
				ShaftController newShaft = Instantiate(_shaftObject, _shaftsTransform.transform);
				newShaft.SetShaft(shaft);
				newShaft.transform.position += _offset*shaft.ShaftNummer;
				_listOfShaftObjects.Add(newShaft);
				_nextShaftNummer = shaft.ShaftNummer;
			}
		}

	}

	private void Prestige()
	{
		_gameData.Shafts.Clear();

		foreach (Transform child in _shaftList.transform)
		{
			Destroy(child.gameObject);
		}
		
		UnlockNewShaft();
		PrestigeFactor += 0.4f;
		Debug.Log("prestiged Factor is: " + PrestigeFactor);
	}
	
	void OnApplicationQuit()
	{
		PlayerPrefs.SetFloat("money", (float) MoneyController.GetMoney());
		string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFilepath);
		string jsonData = JsonConvert.SerializeObject(_gameData);
		Debug.Log(jsonData);
		File.WriteAllText(filePath, jsonData);
	}

	public ShaftController GetCurrentShaftController()
	{
		return _listOfShaftObjects[CurrentShaftNummer];
	}

	public int GetShaftCount()
	{
		return _listOfShaftObjects.Count;
	}
}
