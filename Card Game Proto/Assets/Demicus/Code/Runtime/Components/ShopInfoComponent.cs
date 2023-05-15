using Demicus.Code.Infrastructure.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInfoComponent : MonoBehaviour
{
    public ShopType shopType;
    [SerializeField] public Sprite shopSprite;
    [SerializeField] public Sprite shopOwnerSprite;
    [SerializeField] public List<InventoryItemData> shopItems;
}
