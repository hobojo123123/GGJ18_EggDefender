using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencySystem : MonoBehaviour {

    public bool debug = false;

    int currentMoney;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //print(currentMoney);
		if (debug) {
            // Test Purposes only
            if (Input.GetKeyDown(KeyCode.W)) {
                AddMoney(100);
            }
            if (Input.GetKeyDown(KeyCode.S)) {
                RemoveMoney(50);
            }
        }
	}

    public void AddMoney (int moneyToAdd) {
        currentMoney += moneyToAdd;
    }

    public bool RemoveMoney (int moneyToRemove) {
        bool bRemovedMoney;
        if ((currentMoney - moneyToRemove) >= 0) {
            currentMoney -= moneyToRemove;
            bRemovedMoney = true;
        } else {
            bRemovedMoney = false;
        }
        return bRemovedMoney;
    }
}
