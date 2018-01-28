using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    public int weaponID;

    // On Click
    public void BuyWeapon()
    {
        if(weaponID == 0)
        {
            Debug.Log("No Weapon ID set!!");
            return;
        }

        // NOTE(George): I switched to using a dictionary because
        // it is faster than having to loop through each item with in a list.
        // This also lets us not check to see if the weaponID that the button has
        // is the same as the one the weapon has because we do this in the ContainsKey() function
        // if we do get something then it means it is the same one.
        if(ShopInstance.instance.weapons.ContainsKey(weaponID))
        {
            Weapon weapon = ShopInstance.instance.weapons[weaponID];

            if(!weapon.bought && CurrencySystem.instance.CheckMoney(weapon.weaponPrice))
            {
                // Buy the Item
                weapon.bought = true;
                CurrencySystem.instance.RemoveMoney(weapon.weaponPrice);

                SoundEvents.Instance.Play("LEVEL_COMPLETE_v1_test", false);
            }
            else
            {
                SoundEvents.Instance.Play("LEVEL_FAILED_v1_test", false);
            }
        }

        ShopSystem.instance.UpdateSprite(weaponID);
        ShopSystem.instance.UpdateUI();

        //for (int i = 0; i < ShopSystem.shopSystem.weaponList.Count; i++)
        //{
        //    if(ShopSystem.shopSystem.weaponList[i].weaponID == weaponID &&
        //        !ShopSystem.shopSystem.weaponList[i].bought)
        //    {
        //        // Buy the Item
        //        ShopSystem.shopSystem.weaponList[i].bought = true;
        //        GameManager.gameManager.ReduceMoney(ShopSystem.shopSystem.weaponList[i].weaponPrice);
        //    }
        //}

    }
}
