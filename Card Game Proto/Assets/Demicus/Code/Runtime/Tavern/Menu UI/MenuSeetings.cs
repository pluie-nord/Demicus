using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEditor.Progress;

public class MenuSeetings : MonoBehaviour
{
    private InventorySystem inventorySystem;
    private Dictionary<ItemToSell, GameObject> itemsToSells;
    [SerializeField] private GameObject inventoryGridLayout;
    [SerializeField] private GameObject itemPrefab;

    [SerializeField] private TextMeshProUGUI info_name;
    [SerializeField] private TextMeshProUGUI info_description;
    [SerializeField] private TextMeshProUGUI info_cost;
    [SerializeField] private TextMeshProUGUI info_count;
    [SerializeField] private Image info_icon;

    private ItemToSell currentMenuItem;

    [SerializeField] private GameObject menyGridLayout;
    [SerializeField] private GameObject menuItemPrefab;
    private void Start()
    {
        inventorySystem = FindObjectOfType<InventorySystem>();
        itemsToSells= new Dictionary<ItemToSell, GameObject>();
        foreach(KeyValuePair<ItemToSell, InventoryItemToSell> item in inventorySystem.m_itemToSellDictionary)
        {
            GameObject newItem = Instantiate(itemPrefab);
            newItem.transform.SetParent(inventoryGridLayout.transform);
            newItem.transform.localScale = Vector3.one;

            newItem.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = item.Key.img;
            newItem.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = item.Key.m_name;
            newItem.gameObject.GetComponent<MenuSettingsInventoryItem>().itemData = item.Key;

            itemsToSells.Add(item.Key, newItem);
        }
        UpdateInfoUI();
    }

    public void SetNewItemInfo(ItemToSell itemData)
    {
        info_name.text = itemData.m_name;
        info_description.text = itemData.description;
        info_cost.text = "Цена - "+ itemData.cost.ToString();
        info_count.text = "Количество - " + inventorySystem.m_itemToSellDictionary[itemData].stackSize.ToString();
        info_icon.sprite = itemData.img;
        currentMenuItem = itemData;
    }

    public void AddToMenu()
    {
        if (currentMenuItem != null)
        {
            GameObject newMenuPosition = Instantiate(menuItemPrefab);
            newMenuPosition.transform.SetParent(menyGridLayout.transform);
            newMenuPosition.transform.localScale = Vector3.one;

            newMenuPosition.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = currentMenuItem.m_name;
            newMenuPosition.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = currentMenuItem.cost.ToString();

            inventorySystem.RemoveToSell(currentMenuItem);
            newMenuPosition.GetComponent<MenuListItem>().itemData = currentMenuItem;

            if (inventorySystem.m_itemToSellDictionary.TryGetValue(currentMenuItem, out InventoryItemToSell data))
            {
                info_count.text = "Количество - " + data.stackSize.ToString();
                print(data.stackSize.ToString());
            }
            else
            {
                Destroy(itemsToSells[currentMenuItem]);
                itemsToSells.Remove(currentMenuItem);
                UpdateInfoUI();
            }

            
        }
    }

    public void AddToInventory(ItemToSell itemData)
    {
        if (!inventorySystem.m_itemToSellDictionary.ContainsKey(itemData))
        {
            GameObject newItem = Instantiate(itemPrefab);
            newItem.transform.SetParent(inventoryGridLayout.transform);
            newItem.transform.localScale = Vector3.one;

            newItem.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = itemData.img;
            newItem.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = itemData.m_name;
            newItem.gameObject.GetComponent<MenuSettingsInventoryItem>().itemData = itemData;

            itemsToSells.Add(itemData, newItem);
        }
        inventorySystem.AddToSell(itemData);
        if(currentMenuItem!=null & currentMenuItem==itemData)
        {
            info_count.text = "Количество - " + inventorySystem.m_itemToSellDictionary[itemData].stackSize.ToString();
        }
    }

    private void UpdateInfoUI()
    {
        info_name.text = null;
        info_description.text = null;
        info_cost.text = null;
        info_count.text = null;
        info_icon.sprite = null;
        currentMenuItem = null;
    }


}
