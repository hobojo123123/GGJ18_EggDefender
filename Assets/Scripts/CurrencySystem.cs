using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencySystem : MonoBehaviour {

    public bool debug = false;

    public static CurrencySystem instance = null;
    public float startingMoney = 0;
    private float currentMoney = 0;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    // Use this for initialization
    void Start ()
    {
        AddMoney(startingMoney);
        startingMoney = 0;
	}
	
    public void AddMoney (float amount)
    {
        currentMoney += amount;
    }

    public bool CheckMoney(float amount)
    {
        return (amount <= currentMoney);
    }

    public void RemoveMoney (float amount)
    {
        if(CheckMoney(amount))
        {
            currentMoney -= amount;
        }
    }

    public float GetCurrentMoney()
    {
        return currentMoney;
    }
}
