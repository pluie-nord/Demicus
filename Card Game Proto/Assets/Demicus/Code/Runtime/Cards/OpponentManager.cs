using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OpponentManager : MonoBehaviour
{
    CardHolder cardHolder;
    CardEffectManager cardEffectManager;
    CardManager cardManager;
    [SerializeField] GameObject cardPrefab;
    [SerializeField] Transform cardParent;

    public bool opponentTurn = false;
    private void Start()
    {
        cardHolder = FindObjectOfType<CardHolder>();
        cardEffectManager= FindObjectOfType<CardEffectManager>();
        cardManager = FindObjectOfType<CardManager>();
    }
    public void MakeAMove()
    {
        opponentTurn = true;
        CardObject cardToPlay = cardHolder.opponentDeck[Random.Range(0, cardHolder.opponentDeck.Count)];
        cardManager.attention -= cardToPlay.Attention;
        cardManager.interest -= cardToPlay.Interest;
        cardManager.nonsense += cardToPlay.Nonsense;
        cardManager.UpdateUI();
        if (cardToPlay.CardEffect!=null)
        {
            cardEffectManager.SetPlayerEffectActive(cardToPlay.CardEffect);
        }
        print("Противник сходил "+cardToPlay);

        StartCoroutine(CardUI(cardToPlay));
    }
    private IEnumerator CardUI(CardObject cardToPlay)
    {
        GameObject opponentCard = Instantiate(cardPrefab);
        opponentCard.transform.SetParent(cardParent);
        opponentCard.GetComponent<Card>().cardProperties = cardToPlay;
        opponentCard.transform.localScale = new Vector3(0.454112f, 0.454112f, 0.454112f);
        opponentCard.transform.localPosition = Vector3.zero;
        opponentCard.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = cardToPlay.Description;
        opponentCard.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = " ";
        opponentCard.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = " ";
        yield return new WaitForSeconds(3);
        Destroy(opponentCard);
        //добор карт
        cardManager.TakeNewHand();
        opponentTurn = false;
    }
}
