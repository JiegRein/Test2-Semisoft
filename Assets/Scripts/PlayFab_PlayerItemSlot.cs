using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayFab_PlayerItemSlot : MonoBehaviour
{
    public PlayFab_PlayerItem playerItem;

    private Text text_ItemName;
    private Text text_Amount;


    public void Init(PlayFab_PlayerItem item)
    {
        playerItem = item;
        text_ItemName = transform.GetChild(0).GetComponent<Text>();
        text_Amount = transform.GetChild(1).GetComponent<Text>();

        UpdateUI();
    }

    public void UpdateUI()
    {
        text_ItemName.text = playerItem.itemName;
        text_Amount.text = playerItem.amount.ToString();
    }
}
