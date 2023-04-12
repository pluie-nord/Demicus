using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuListItem : MonoBehaviour
{
    public ItemToSell itemData;
    private void OnMouseDown()
    {
        FindObjectOfType<MenuSeetings>().AddToInventory(itemData);
        Destroy(gameObject);
    }
}
