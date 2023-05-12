using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryUIManager : MonoBehaviour
{
    [SerializeField] GameObject inventoryDisplay;
    //[SerializeField] Controller controller;
    [SerializeField] GameObject itemPrefab;
    [SerializeField] GameObject layoutObject;
    private Dictionary<string, GameObject> UIitems;
    public bool inventoryActive = false;

    private void Start()
    {
        UIitems = new Dictionary<string, GameObject>();
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if (!inventoryActive)
            {
                inventoryDisplay.SetActive(true);
                inventoryActive = true;
                Time.timeScale = 0;
                //controller.enabled = false;
            }
            else
            {
                inventoryDisplay.SetActive(false);
                inventoryActive = false;
                Time.timeScale = 1;
                //controller.enabled = true;
            }
        }
    }

    public void AddToInventory(InventoryItemData newData)
    {
        GameObject newItem = Instantiate(itemPrefab);
        newItem.transform.SetParent(layoutObject.transform);
        newItem.transform.localScale = new Vector3(1, 1, 1);
        newItem.transform.GetChild(0).GetComponent<Image>().sprite = newData.icon;
        UIitems.Add(newData.id, newItem);
    }

    public void RemoveFromInventory(InventoryItemData itemData, int stackSize)
    {
        if(stackSize==0)
        {
            if (UIitems.TryGetValue(itemData.id, out GameObject objectToStack))
            {
                UIitems.Remove(itemData.id);
                Destroy(objectToStack);
            }
        }
        else
        {
            StackToInventory(itemData, stackSize);
        }
    }

    public void StackToInventory(InventoryItemData referenceData, int stackSize)
    {
        if(UIitems.TryGetValue(referenceData.id, out GameObject objectToStack))
        {
            objectToStack.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = " " + stackSize;
        }
    }

}
