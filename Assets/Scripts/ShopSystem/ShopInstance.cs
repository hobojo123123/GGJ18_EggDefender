using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInstance : MonoBehaviour
{
    public static ShopInstance instance = null;
    
    public List<Weapon> weaponStoreList = new List<Weapon>();    // We still need to keep this to populate the list through the inspector
    public Dictionary<int, Weapon> weapons = new Dictionary<int, Weapon>();
    public Dictionary<int, StoreItems> holderItems = new Dictionary<int, StoreItems>();

    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    private void Start()
    {
        foreach(Weapon weapon in weaponStoreList)
        {
            if(!weapons.ContainsKey(weapon.weaponID))
                weapons.Add(weapon.weaponID, weapon);
        }
    }
}
