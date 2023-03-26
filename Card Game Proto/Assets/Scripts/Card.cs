using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    CardManager cardManager;
    public CardObject cardProperties;
    public int handIndex = 0;
    void Start()
    {
        cardManager = FindObjectOfType<CardManager>();
    }
    private void OnMouseDown()
    {
        if (!FindObjectOfType<OpponentManager>().opponentTurn)
        {
            cardManager.PlayCard(cardProperties, gameObject, handIndex);
        }

    }
}
