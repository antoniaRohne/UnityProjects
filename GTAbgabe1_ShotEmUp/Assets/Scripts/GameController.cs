using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : Singleton<GameController> {

    PointCounter pc;
    [SerializeField]
    GameObject playerPrefab;
    [SerializeField]
    EnemyInstantiater enemyInstant;
    [SerializeField]
    AmmoInstantiater ammoInstant;
    [SerializeField]
    Scroll scrollBackground;
    private GameObject playerObj;
    public GameState currentState = GameState.NONE;
    public static GameController instance = null;

    public int ammo;
    [SerializeField]
    Text ammoDisplay;

    public enum GameState{
        PLAYING,
        ENDING,
        NONE
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        pc = GameObject.Find("GameController").GetComponent<PointCounter>();
        setNextState(GameState.PLAYING);
    }
    private void Update()
    {

        if(Input.GetKey(KeyCode.Escape)){
            Application.Quit();
        }
        
        switch (currentState)
        {
            case GameState.PLAYING: 
                ammoDisplay.text = ammo.ToString();
                break;

            case GameState.ENDING:

                if (Input.GetKey("x"))
                {
                    setNextState(GameState.PLAYING);
                }
                break;

            case GameState.NONE: 
                break;
        }
    }

    private void setNextState(GameState state)
    {
        if(currentState.Equals(state))
        {
            return;
        }

        switch (state)
        {
            case GameState.PLAYING:
                setUpGame();
                break;

            case GameState.ENDING:
                cleanUpGame();
                break;

            case GameState.NONE:
                break;
        }

        currentState = state;
    }

    public void addPoint()
    {
        pc.addPoint();
    }

      public void addAmmo()
    {
        ammo+=3;
    }

    public void endGame() {
        setNextState(GameState.ENDING);
    }

    public bool getStatus()
    {
        if (currentState.Equals(GameState.PLAYING))
        {
            return true;
        }
        return false;
    }

    public void setUpGame()
    {
        pc.resetPoints();
        ammo = 10;
        playerObj = Instantiate(playerPrefab);
        enemyInstant.init();
        ammoInstant.init();
        scrollBackground.setSpeed(0.5f);
    }

     public void cleanUpGame()
    {
        pc.setPoints();
        enemyInstant.stop();
        ammoInstant.stop();
        scrollBackground.setSpeed(0);
        Destroy(playerObj);
    }
}
