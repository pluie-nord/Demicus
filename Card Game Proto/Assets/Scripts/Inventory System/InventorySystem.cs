using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventorySystem : MonoBehaviour
{
    public static InventorySystem Instance { get; set; }
    public delegate void InventoryEventHandler(InventoryItemData item);
    public static event InventoryEventHandler OnCollectItem;

    public static void ItemCollected(InventoryItemData item)
    {
        OnCollectItem?.Invoke(item);
    }

    public Dictionary<InventoryItemData, InventoryItem> m_itemDictionary;
    public List<InventoryItem> inventory { get; set; }
    [SerializeField] List<InventoryItemData> m_items;
    private InventoryUIManager inventoryUI;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
        DontDestroyOnLoad(this);
        inventory = new List<InventoryItem>();
        m_itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();
        inventoryUI = FindObjectOfType<InventoryUIManager>();

        foreach(InventoryItemData newItemData in m_items)
        {
            Add(newItemData);
        }
    }

    public void Add(InventoryItemData referenceData)
    {
        if (m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.AddToStack();
            inventoryUI.StackToInventory(referenceData, value.stackSize);
        }
        else
        {
            InventoryItem newItem = new InventoryItem(referenceData);
            inventory.Add(newItem);
            m_itemDictionary.Add(referenceData, newItem);
            //inventoryUI.AddToInventory(referenceData);
            //inventoryUI.StackToInventory(referenceData, newItem.stackSize);
        }
    }

    public void Remove(InventoryItemData referenceData)
    {
        if(m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.RemoveFromStack();
            //inventoryUI.RemoveFromInventory(referenceData, value.stackSize);
            if(value.stackSize==0)
            {
                inventory.Remove(value);
                m_itemDictionary.Remove(referenceData);
            }
        }
    }

}

public class InventoryItem
{
    public InventoryItemData data { get; private set; }
    public int stackSize { get; private set; }

    public InventoryItem(InventoryItemData source)
    {
        data = source;
        AddToStack();
    }

    public void AddToStack()
    {
        stackSize++;
        Debug.Log(stackSize + " " + data.displayName);
    }

    public void RemoveFromStack()
    {
        stackSize--;
    }

}
