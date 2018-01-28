using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveStoreButton : MonoBehaviour
{
    public string LevelNameToLoad = "Shop";
    public void OnLeaveStorePressed()
    {
        ShopInstance.instance.holderItems.Clear();
        if(GameState.instance != null)
            GameState.instance.shopClosed();
        SceneManager.LoadScene(LevelNameToLoad);
    }
}
