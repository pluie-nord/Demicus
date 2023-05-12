using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Recipe")]
public class Recipe : ScriptableObject
{
    //id приготовленного, name, иконка, description, список Id ингридиентов, стоимость
    public string id;
    public string m_name;
    public Sprite img;
    public string description;
    public List<InventoryItemData> ingredients;
    public int cost;
}
