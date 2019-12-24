using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;
using UnityEngine.UI;

public class PlayFab_Transaction : MonoBehaviour
{
    public Text itemID;
    public Text itemPrice;
    public void OnClickBuy()
    {
        PurchaseItemRequest purchaseItem = GetPurchaseItem();
        purchaseItem.ItemId = itemID.text;
        Int32.TryParse(itemPrice.text, out purchaseItem.Price);
        purchaseItem.VirtualCurrency = "GO";
        purchaseItem.StoreId = "MainStore";
        PlayFabClientAPI.PurchaseItem(purchaseItem, result =>
        {
            Debug.Log("Success");
        }, error =>
        {
            Debug.Log(error.ErrorMessage);
        });
    }

    private static PurchaseItemRequest GetPurchaseItem()
    {
        return new PurchaseItemRequest();
    }
}
