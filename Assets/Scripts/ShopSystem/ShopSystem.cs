using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSystem : MonoBehaviour {

    public static ShopSystem shopSystem;

    public List<Weapon> weaponList = new List<Weapon>();

    public GameObject itemHolderPrefab;
    public Transform grid;

	// Use this for initialization
	void Start () { 
        shopSystem = this;
        FillList();		
	}
	
    // This will look through the weaponList and place all items in the shop
	void FillList(){

        for(int i = 0; i < weaponList.Count; i++){

            GameObject holder = Instantiate(itemHolderPrefab,grid, false);
            StoreItems holderScript = holder.GetComponent<StoreItems>();

            holderScript.itemName.text = weaponList[i].weaponName;
            holderScript.itemPrice.text = "$ " + weaponList[i].weaponPrice.ToString();
            holderScript.itemID = weaponList[i].weaponID;

            // Using the Buy Button
            holderScript.buybutton.GetComponent<BuyButton>().weaponID = weaponList[i].weaponID;

            if(weaponList[i].bought == true){
                holderScript.itemImage.sprite = weaponList[i].boughtSprite;
            }else {
                holderScript.itemImage.sprite = weaponList[i].unboughtSprite;
            }
                
        }
    }
}
