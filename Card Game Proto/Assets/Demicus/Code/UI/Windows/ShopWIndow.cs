using Demicus.Code.Infrastructure.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopWIndow : MonoBehaviour
{
    [SerializeField] private Button _talkBtn;
    [SerializeField] private Button _shopBtn;

    [SerializeField] private Image _shopImage;
    [SerializeField] private Image _shopOwnerImage;

    [SerializeField] private GameObject _shopObject;
    [SerializeField] private GameObject _shopItemPrefab;
    [SerializeField] private Transform _shopGridParent;


    private ShopType _shopType;
    private Sprite _shopSprite;
    private Sprite _shopOwnerSprite;
    private List<InventoryItemData> _shopItems;

    private void Awake()
    {
        Subscribe();
    }

    private void Subscribe()
    {
        _shopBtn.onClick.AddListener(OpenShop);
    }

    public void SetInfo(ShopType shopType, Sprite shopSprite, Sprite shopOwnerSprite, List<InventoryItemData> shopItems)
    {
        _shopType = shopType;
        _shopSprite = shopSprite;   
        _shopOwnerSprite = shopOwnerSprite;
        _shopItems = shopItems;
        SetImages();
    }

    private void SetImages()
    {
        _shopImage.sprite = _shopSprite;
        _shopOwnerImage.sprite = _shopOwnerSprite;
    }

    private List<GameObject> _shopItemsGO = new List<GameObject>();

    private void OpenShop()
    {
        _shopObject.SetActive(true);
        foreach(InventoryItemData item in _shopItems) 
        {
            GameObject newItem = Instantiate(_shopItemPrefab);
            newItem.transform.SetParent(_shopGridParent);
            newItem.transform.localScale = Vector3.one;
            newItem.GetComponent<ShopItem>().inventoryItemData = item;
            newItem.GetComponent<ShopItem>().SetInfo();
            _shopItemsGO.Add(newItem);
        }
    }

    public void CloseShop()
    {
        _shopItemsGO.ForEach(child => Destroy(child));
        _shopObject.SetActive(false);
    }

}
