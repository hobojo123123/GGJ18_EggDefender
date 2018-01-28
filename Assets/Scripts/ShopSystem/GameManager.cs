using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //public static GameManager instance = null;
    [SerializeField] private float _Money = 0;

    public Text moneyText;
    
    private void Awake()
    {
        //DontDestroyOnLoad(this);
        //if (instance == null)
        //    instance = this;
        //else
        //    Destroy(this);
    }

    // Use this for initialization
    void Start ()
    {
        //UpdateUI(CurrencySystem.instance.GetCurrentMoney());
	}	

    // Adds money to wallet
    public void AddMoney (float amount)
    {
        _Money += amount;
        UpdateUI(CurrencySystem.instance.GetCurrentMoney());
    }

    // Subtracts money from wallet after item is bought
    public void ReduceMoney (float amount)
    {
        UpdateUI(CurrencySystem.instance.GetCurrentMoney());
    }
    
    // Checks to see if player has the correct amount to buy item from store
    public bool CheckMoney (float amount)
    {
        return (amount <= _Money);  // NOTE(George): Much simpler to write than if() else statements.
    }

    // This will update the players current money after purchase
    void UpdateUI(float amount)
    {
        moneyText.text = "$ " + amount.ToString("N2");
    }
}
