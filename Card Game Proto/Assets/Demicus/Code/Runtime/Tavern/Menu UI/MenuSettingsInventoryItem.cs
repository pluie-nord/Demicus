using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSettingsInventoryItem : MonoBehaviour
{
    public ItemToSell itemData;
    private void OnMouseDown()
    {
        FindObjectOfType<MenuSeetings>().SetNewItemInfo(itemData);
    }
}
