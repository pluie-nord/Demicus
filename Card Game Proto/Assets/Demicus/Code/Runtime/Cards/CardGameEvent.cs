using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGameEvent : MonoBehaviour
{
    public delegate void CardEventHandler(int nonsensePoints);
    public static event CardEventHandler OnNonsenseGained;
    public static event CardEventHandler OnAttentionSpent;

    public static void NonsenseGained(int nonsensePoints)
    {
        OnNonsenseGained?.Invoke(nonsensePoints);
    }

    public static void AttentionSpent(int attention)
    {
        OnAttentionSpent?.Invoke(attention);
    }
}
