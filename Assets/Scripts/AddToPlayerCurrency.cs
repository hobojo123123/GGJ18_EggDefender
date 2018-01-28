using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToPlayerCurrency : MonoBehaviour {

    // How much currency to add to the players currency count
    public int currencyToAdd;
    // Set _currencySystem to the player's CurrencySystem script
    public CurrencySystem _currencySystem;

    void AddCurrency () {
        _currencySystem.AddMoney(currencyToAdd);
    }
    
}
