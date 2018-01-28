using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSystem : MonoBehaviour
{
    public static ShopSystem instance = null;

    //public List<Weapon> weaponList = new List<Weapon>();    // We still need to keep this to populate the list through the inspector
    //public Dictionary<int, Weapon> weapons = new Dictionary<int, Weapon>();
    //public Dictionary<int, StoreItems> holderItems = new Dictionary<int, StoreItems>();

    public GameObject itemHolderPrefab;
    public Transform grid;

    public Text moneyText;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    // Use this for initialization
    void Start ()
    {
        UpdateUI();
        FillList();
	}
	
    // This will look through the weaponList and place all items in the shop
	void FillList()
    {
        for(int i = 0; i < ShopInstance.instance.weaponStoreList.Count; i++)
        {
            // NOTE(George): I decided to extract the weapon from the list 
            // and have it handy so we dont have to keep indexing into the array/list.
            // This might get compiled to do this but it is in good practice to do it 
            // yourself becuase some compilers will not be so smart to keep that memory handy.
            // It is also much nicer and shorter to write.
            Weapon weapon = ShopInstance.instance.weaponStoreList[i];
            //ShopInstance.instance.weapons.Add(weapon.weaponID, weapon);

            GameObject holder = Instantiate(itemHolderPrefab,grid, false);
            StoreItems holderScript = holder.GetComponent<StoreItems>();
            
            holderScript.itemName.text = weapon.weaponName;
            holderScript.itemPrice.text = "$ " + weapon.weaponPrice.ToString();
            holderScript.itemID = weapon.weaponID;

            // Using the Buy Button
            holderScript.buybutton.GetComponent<BuyButton>().weaponID = weapon.weaponID;

            if(!ShopInstance.instance.holderItems.ContainsKey(weapon.weaponID))
                ShopInstance.instance.holderItems.Add(weapon.weaponID, holderScript);

            UpdateSprite(weapon.weaponID);

            if (weapon.bought == true)
            {
                holderScript.itemImage.sprite = Resources.Load<Sprite>("Sprites/" + weapon.boughtSprite);
            }
            else
            {
                holderScript.itemImage.sprite = Resources.Load<Sprite>("Sprites/" + weapon.unboughtSprite);
            }
        }
    }

    public void UpdateSprite(int weaponID)
    {
        if(ShopInstance.instance.holderItems.ContainsKey(weaponID))
        {
            if(ShopInstance.instance.weapons.ContainsKey(weaponID))
            {
                StoreItems Item = ShopInstance.instance.holderItems[weaponID];
                Weapon weapon = ShopInstance.instance.weapons[weaponID];
                
                if(weapon.bought)
                {
                    // Change sprites
                    Item.itemImage.sprite = Resources.Load<Sprite>("Sprites/" + weapon.boughtSprite);
                    Item.itemPrice.text = "Sold Out!";
                    Item.itemPrice.color = Color.red;
                }
            }
        }
    }
    
    // This will update the players current money after purchase
    public void UpdateUI()
    {
        float amount = CurrencySystem.instance.GetCurrentMoney();
        moneyText.text = "$ " + amount.ToString("N2");
    }
}
