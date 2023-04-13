using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    [SerializeField] InventoryItemData inventoryItemData;
    private void OnMouseDown()
    {
        FindObjectOfType<InventorySystem>().Add(inventoryItemData);
    }
}
