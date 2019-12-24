using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayFab_PlayerItem : MonoBehaviour
{
    public string itemName;
    public int? amount;

    public PlayFab_PlayerItem(string itemName, int? amount)
    {
        this.itemName = itemName;
        this.amount = amount;
    }
}
