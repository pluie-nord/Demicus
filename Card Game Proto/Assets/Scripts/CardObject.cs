using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card")]
public class CardObject : ScriptableObject
{
    public enum myTypes
    {
        story,
        action_pos,
        action_neg
    };

    public myTypes Type = myTypes.story;

    public int Attention;
    public int Interest;
    public int Nonsense;
    [TextArea] public string Description;
    public Image CardDesign;
    public Effect CardEffect;
}
