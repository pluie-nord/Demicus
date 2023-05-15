using Demicus.Code.Infrastructure.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorplanManager : MonoBehaviour
{
    [SerializeField] private List<FloorplanItem> _floorplanItems;
    [SerializeField] private Transform _catalogParent;
    [SerializeField] private GameObject _catalogItemPrefab;

    private void Start()
    {
        SetItems(FloorplanType.Tables);
    }

    private void SetItems(FloorplanType itemType)
    {
        foreach (var floorplanItem in _floorplanItems)
        {
            if (floorplanItem.itemType == itemType)
            {
                foreach (Sprite sprite in floorplanItem.sprites)
                {
                    GameObject newItem = Instantiate(_catalogItemPrefab);
                    newItem.transform.SetParent(_catalogParent);
                    newItem.transform.localScale = Vector3.one;
                    newItem.GetComponent<Image>().sprite = sprite;
                    CatalogItem newItemInfo = new CatalogItem();
                    newItemInfo.sprite = sprite;
                    newItemInfo.spriteObj = floorplanItem.spriteObj;
                    newItemInfo.hubSpriteObj = floorplanItem.hubSpriteObj;
                    newItem.GetComponent<CatalogItemComponent>().itemInfo = newItemInfo;
                    newItem.GetComponent<CatalogItemComponent>().onItemClicked += SetImage;
                }


            }
        }
    }

    private void SetImage(CatalogItem itemInfo)
    {
        itemInfo.spriteObj.GetComponent<Image>().sprite = itemInfo.sprite;
        itemInfo.hubSpriteObj.GetComponent<Image>().sprite = itemInfo.sprite;
    }

}

[System.Serializable]
public struct FloorplanItem
{
    public FloorplanType itemType;
    public List<Sprite> sprites;
    [SerializeField] public GameObject spriteObj;
    [SerializeField] public GameObject hubSpriteObj;
}

public struct CatalogItem
{
    public GameObject spriteObj;
    public GameObject hubSpriteObj;
    public Sprite sprite;
}

