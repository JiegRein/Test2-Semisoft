using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;
using UnityEngine.UI;

public class PlayFab_PlayerData : MonoBehaviour
{
    public List<PlayFab_PlayerItem> ListAllPlayerItem = new List<PlayFab_PlayerItem>();
    public Text text_GoldDisplay;
    public Text text_GoldAdd;
    public Text text_GoldSubtract;

    private int amountAdded;

    public void GetUserIventory()
    {
        PlayFabClientAPI.GetUserInventory(new GetUserInventoryRequest(), result =>
        {
            Debug.Log("Success");
            int goldValue = result.VirtualCurrency["GO"];
            foreach (var item in result.Inventory)
            {
                PlayFab_PlayerItem inventoryItem = new PlayFab_PlayerItem(item.DisplayName, item.RemainingUses);
                ListAllPlayerItem.Add(inventoryItem);
            }
            Debug.Log("Player Item Count : "+ListAllPlayerItem.Count);
            text_GoldDisplay.text = "Gold = "+goldValue.ToString();
        }, error => {
            Debug.Log("Yikes");
        });
    }

    public IEnumerator GetUserCurrency()
    {

        yield return new WaitForSeconds(2f);
        PlayFabClientAPI.GetUserInventory(new GetUserInventoryRequest(), result =>
        {
            Debug.Log("Success");
            int goldValue = result.VirtualCurrency["GO"];            
            Debug.Log("Player Item Count : " + ListAllPlayerItem.Count);
            text_GoldDisplay.text = "Gold = " + goldValue.ToString();
        }, error => {
            Debug.Log("Yikes");
        });
        yield return null;
    }

    public void AddVirtualCurrency()
    {
        Int32.TryParse(text_GoldAdd.text, out amountAdded);
        AddUserVirtualCurrencyRequest toBeAdded = new AddUserVirtualCurrencyRequest
        {
            Amount = amountAdded,
            VirtualCurrency = "GO"
        };
        PlayFabClientAPI.AddUserVirtualCurrency(toBeAdded, result => {
            Debug.Log("ITEM LIST = " + ListAllPlayerItem.Count);
            Debug.Log(toBeAdded.Amount);
            Debug.Log("Success");
            Debug.Log(result.Balance);
        }, error => {
            Debug.Log("Lost");
            Debug.Log(error.ErrorMessage);
        });
        StartCoroutine(GetUserCurrency());
    }

    public void SubstractVirtualCurrency()
    {
        Debug.Log("ITEM LIST = " + ListAllPlayerItem.Count);
        Int32.TryParse(text_GoldSubtract.text, out amountAdded);
        SubtractUserVirtualCurrencyRequest tobeSubtract = new SubtractUserVirtualCurrencyRequest
        {
            Amount = amountAdded,
            VirtualCurrency = "GO"
        };
        PlayFabClientAPI.SubtractUserVirtualCurrency(tobeSubtract, result => {
            Debug.Log(tobeSubtract.Amount);
            Debug.Log("Success");
            Debug.Log(result.Balance);
        }, error => {
            Debug.Log("Lost");
            Debug.Log(error.ErrorMessage);
        });
        StartCoroutine(GetUserCurrency());
    }

    public List<PlayFab_PlayerItem> GetListPlayerItem()
    {
        return ListAllPlayerItem;
    }
}
