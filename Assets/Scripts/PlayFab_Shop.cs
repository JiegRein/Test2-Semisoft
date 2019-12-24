using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class PlayFab_Shop : MonoBehaviour
{
    public PlayFab_ShopItem storeItem;
    public List<PlayFab_ShopItem> ListShopItem = new List<PlayFab_ShopItem>();
    public List<PlayFab_ShopItemSlot> ListSlotItem = new List<PlayFab_ShopItemSlot>();

    public GameObject _storeItem;
    public GameObject shopSpacer;
    public void Awake()
    {
        GetAllItem();
        StartCoroutine(ShowAllItems());
    }
    public IEnumerator ShowAllItems()
    {
        yield return new WaitForSeconds(2f);
        foreach (var item in ListShopItem)
        {
            GameObject GO = Instantiate(_storeItem, Vector3.zero, Quaternion.identity);

            PlayFab_ShopItemSlot storeItem = GO.GetComponent<PlayFab_ShopItemSlot>();
            storeItem.Init(item);

            ListSlotItem.Add(storeItem);

            GO.transform.SetParent(shopSpacer.transform);
            GO.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void GetAllItem()
    {
        GetStoreItemsRequest storeItems = GetStoreItems();
        storeItems.CatalogVersion = "main";
        storeItems.StoreId = "MainStore";
        PlayFabClientAPI.GetStoreItems(storeItems, result =>
        {
            Debug.Log(result.Store.Count);
            foreach (var item in result.Store)
            {
                Debug.Log("Penting : " + item.ItemId);
                Debug.Log("Penting : " + item.VirtualCurrencyPrices["GO"]);
                PlayFab_ShopItem shopItem = new PlayFab_ShopItem(item.ItemId, item.VirtualCurrencyPrices["GO"]);
                ListShopItem.Add(shopItem);
            }
            Debug.Log(ListShopItem.Count);
        }, error =>
        {
            Debug.Log(error.ErrorMessage);
        });
    }

    private static GetStoreItemsRequest GetStoreItems()
    {
        return new GetStoreItemsRequest();
    }

}
