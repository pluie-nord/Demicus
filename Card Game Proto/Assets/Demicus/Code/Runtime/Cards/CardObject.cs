using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Card")]
public class CardObject : ScriptableObject
{
    public enum myTypes
    {
        story,
        action_pos,
        action_neg
    };

    public enum myStoryTypes
    {
        action,
        place
    }

    public myTypes Type = myTypes.story;
    public myStoryTypes StoryCardType;
    public myStoryTypes NextStoryCardType;

    public string Name;
    public int Attention;
    public int Interest;
    public int Nonsense;
    [TextArea] public string Description;
    [TextArea] public string StoryDescription;
    [TextArea] public string GamePhrase;
    public Effect CardEffect;
    public Sprite bgIcon;
    public Sprite SideParts;
}
