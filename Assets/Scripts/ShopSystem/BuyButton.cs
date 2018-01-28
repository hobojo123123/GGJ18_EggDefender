using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButton : MonoBehaviour {

    public int weaponID;

    // On Click
    public void BuyWeapon(){ 
        if(weaponID == 0){
            Debug.Log("No Weapon ID set!!");
            return;
        }

        for(int i = 0; i < ShopSystem.shopSystem.weaponList.Count; i++){
            if(ShopSystem.shopSystem.weaponList[i].weaponID == weaponID && !ShopSystem.shopSystem.weaponList[i].bought)
            {
                // Buy the Item
                ShopSystem.shopSystem.weaponList[i].bought = true;
                GameManager.gameManager.ReduceMoney(ShopSystem.shopSystem.weaponList[i].weaponPrice);
            }


        }

    }
}
