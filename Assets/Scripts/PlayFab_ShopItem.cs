using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFab_ShopItem : MonoBehaviour
{
    public string itemID;
    public uint unitPrice;

    public PlayFab_ShopItem(string itemID, uint unitPrice)
    {
        this.itemID = itemID;
        this.unitPrice = unitPrice;
    }

    public void SetItem(string _itemId, uint _unitPrice)
    {
        itemID = _itemId;
        unitPrice = _unitPrice;
    }
}
