using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card Effect")]
public class Effect : ScriptableObject
{
    public enum myActionTypes
    {
        interest,
        attention,
        deck
    }
    public enum myTimeTypes
    {
        per_card,
        per_turn
    }
    public myActionTypes actionType = myActionTypes.interest;
    public myTimeTypes timeType= myTimeTypes.per_card;
    public int value;
    public bool active;
    public int time;
    public Sprite icon;
}
