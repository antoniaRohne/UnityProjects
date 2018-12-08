using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController: MonoBehaviour
    {

        public static GameController instance = null;
        UIController ui;
        GameObject player;

       public enum GameState
       {
            Play,GameEnd
       }

    GameState current;


    //Awake is always called before any Start functions
    void Awake()
        {
            if (instance == null)
                instance = this;
    
           else if (instance != this)
                Destroy(gameObject);    
           
            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {
            if(current == GameState.GameEnd)
            {
                if (Input.GetKey(KeyCode.X))
                {
                    SceneManager.LoadScene("CrawlWalkRun2");
                }
            }
        }

    private void switchState(GameState g)
        {
            switch (g)
            {
                case GameState.Play:
                current = GameState.Play;
                ui = FindObjectOfType<UIController>();
                ui.setAmountOfItems(5);
                player = GameObject.FindGameObjectWithTag("Player");
                break;
                case GameState.GameEnd:
                current = GameState.GameEnd;
                Destroy(player.GetComponent("moveBehaviour")); break;
            }    
        }

        private void Start()
        {
            switchState(GameState.Play);
        }

         public void collected()
        {
            ui.increaseAmountOfItems();
        }

        public void hit()
        {
            ui.reduceAmountOfItems();
    
        }

        public void win()
        {
            ui.showWin();
            switchState(GameState.GameEnd);
    }

        public void gameOver()
        {
            switchState(GameState.GameEnd);
        }

	}
        