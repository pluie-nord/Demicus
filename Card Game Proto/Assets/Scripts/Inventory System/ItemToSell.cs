using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item To Sell")]
public class ItemToSell : ScriptableObject
{
    public string id;
    public string m_name;
    public Sprite img;
    public string description;
    public int cost;
}
