using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager gameManager;
    [SerializeField] private float _Money = 0;

    public Text moneyText;


	// Use this for initialization
	void Start () {

        gameManager = this;
        UpdateUI();
		
	}	

    // Adds money to wallet
    public void AddMoney (float amount){
        _Money += amount;
        UpdateUI();
    }

    // Subtracts money from wallet after item is bought
    public void ReduceMoney (float amount){
        _Money -= amount;
        UpdateUI();
    }

    // Checks to see if player has the correct amount to buy item from store
    public bool CheckMoney (float amount){

        if(amount <= _Money){
            return true;
        }
        return false;
    }

    // This will update the players current money after purchase
    void UpdateUI(){
        moneyText.text = "$ " + _Money.ToString("N2");
    }
}
