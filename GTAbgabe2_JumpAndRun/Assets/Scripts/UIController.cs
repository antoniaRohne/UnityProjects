using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    [SerializeField]
    Text amountOfItems;
    [SerializeField]
    GameObject gameOver;
    [SerializeField]
    GameObject win;

    int amount = 0;

    public void setAmountOfItems(int amount){
        this.amount = amount;
        amountOfItems.text = amount.ToString();
	}

    public void increaseAmountOfItems()
    {
        amount++;
        amountOfItems.text = amount.ToString();
    }

    public void reduceAmountOfItems()
    {
        amount--;

        if (amount == 0)
        {
            amountOfItems.text = amount.ToString();
            gameOver.SetActive(true);
            GameController.instance.gameOver();
            
        }
        else
            amountOfItems.text = amount.ToString();
    }

    public void showWin()
    {
        win.SetActive(true);
    }
}
