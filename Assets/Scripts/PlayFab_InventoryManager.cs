using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFab_InventoryManager : MonoBehaviour
{
    public List<PlayFab_PlayerItemSlot> ListPlayerItemSlot = new List<PlayFab_PlayerItemSlot>();

    public PlayFab_PlayerData PlayerData;

    public GameObject InventorySpacer;
    public GameObject PlayerItem;
    public void Awake()
    {
        PlayerData.GetUserIventory();
        StartCoroutine(GetAllPlayerInventoryItems());
    }
    public IEnumerator GetAllPlayerInventoryItems()
    {
        yield return new WaitForSeconds(2f);
        foreach (var item in PlayerData.GetListPlayerItem())
        {
            GameObject GO = Instantiate(PlayerItem, Vector3.zero, Quaternion.identity);

            PlayFab_PlayerItemSlot playerItem = GO.GetComponent<PlayFab_PlayerItemSlot>();
            playerItem.Init(item);

            ListPlayerItemSlot.Add(playerItem);

            GO.transform.SetParent(InventorySpacer.transform);
            GO.transform.localScale = new Vector3(1,1,1);
        }
    }
}
