using Demicus.Code.Infrastructure.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatalogItemComponent : MonoBehaviour
{
    public CatalogItem itemInfo;
    public event Action<CatalogItem> onItemClicked;

    private void OnMouseDown()
    {
        onItemClicked?.Invoke(itemInfo);
    }

}