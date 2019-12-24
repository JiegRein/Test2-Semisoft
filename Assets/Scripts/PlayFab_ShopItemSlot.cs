using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayFab_ShopItemSlot : MonoBehaviour
{   
    public PlayFab_ShopItem shopItem;
    private Text text_ItemID;
    private Text text_ItemPrice;

    public void Init(PlayFab_ShopItem item)
    {
        shopItem = item;
        text_ItemID = transform.GetChild(0).GetComponent<Text>();
        text_ItemPrice = transform.GetChild(1).GetComponent<Text>();

        UpdateUI();
    }

    public void UpdateUI()
    {
        text_ItemID.text = shopItem.itemID;
        text_ItemPrice.text = shopItem.unitPrice.ToString();
    }
}
