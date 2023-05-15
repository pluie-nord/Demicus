using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [SerializeField] public InventoryItemData inventoryItemData;
    private void OnMouseDown()
    {
        FindObjectOfType<InventorySystem>().Add(inventoryItemData);
    }
    public void SetInfo()
    {
        transform.GetChild(0).GetComponent<Image>().sprite = inventoryItemData.icon;
        transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = inventoryItemData.displayName;
    }
}
