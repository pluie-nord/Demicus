using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    CardHolder cardHolder;
    public int attention=0;
    public int interest=0;
    public int nonsense = 0;

    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private GameObject cardHand;
    [SerializeField] private GameObject cardStand;
    [SerializeField] private TextMeshProUGUI deckCardsUI;

    [SerializeField] Button nextTurnBtn;

    private void Start()
    {
        cardHolder = FindObjectOfType<CardHolder>();
        nextTurnBtn.interactable = true;
    }
    public void TakeCard(CardObject newHandCard) //�������� ����� �� ����
    {
        for(int i = 0; i<6; i++)
        {
            if (cardHolder.hand[i]==null)
            {
                cardHolder.hand[i]= newHandCard;
                //�������� ����� ���������. instatiate
                GameObject newCard = Instantiate(cardPrefab);
                newCard.transform.SetParent(cardHand.transform);
                newCard.GetComponent<Card>().cardProperties = newHandCard;
                newCard.transform.localScale = Vector3.one;
                newCard.transform.localPosition = new Vector3(215 * (i), newCard.transform.localPosition.y);
                newCard.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = newHandCard.Description;
                newCard.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = newHandCard.Attention.ToString();
                newCard.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = newHandCard.Interest.ToString();

                newCard.GetComponent<Card>().handIndex = i;

                break;
            }
        }
        
    }

    public void SwitchCards(CardObject switchTo, CardObject switchFrom)
    {
        
        cardHolder.hand[cardHolder.hand.IndexOf(switchFrom)]= switchTo;
        //cardHolder.deck.Add(switchFrom);
        cardHolder.deck.Remove(switchTo);
        GameObject newCard = Instantiate(cardPrefab);
        newCard.transform.SetParent(cardHand.transform);
        newCard.GetComponent<Card>().cardProperties = switchTo;
        newCard.transform.localScale = Vector3.one;
        newCard.transform.localPosition = new Vector3(215 * cardHolder.hand.IndexOf(switchTo), newCard.transform.localPosition.y);
        newCard.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = switchTo.Description;
        newCard.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = switchTo.Attention.ToString();
        newCard.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = switchTo.Interest.ToString();
        newCard.GetComponent<Card>().handIndex = cardHolder.hand.IndexOf(switchTo);
        UpdateUI();
    }

    public void PlayCard(CardObject card, GameObject cardObject, int index) //��������� �����
    {
        //��������� �������� ������� ������� ��������� �� ������
        if(card.Attention!=0)
        {
            FindObjectOfType<CardEffectManager>().PlayEffects(Effect.myTimeTypes.per_card);
        }
        bool isSwitch = false;
        switch (card.Type)
        {
            case CardObject.myTypes.story:
                //����������� ����� �������
                cardHolder.story.Add(card);
                AddPoints(card.Attention, card.Interest, 0);
                //�������� ����� �� ���� ���������
                GameObject newStoryCard = Instantiate(cardObject);
                newStoryCard.transform.SetParent(cardStand.transform);
                newStoryCard.transform.localPosition = new Vector3(215 * (cardHolder.story.Count-1), 365);
                newStoryCard.transform.localScale = Vector3.one;
                break;
            case CardObject.myTypes.action_pos:
                //����� �������� �� ������� ������
                interest += card.Interest;
                attention -= card.Attention;
                nonsense += card.Nonsense;
                UpdateUI();
                if(card.CardEffect!=null)
                {
                    //������������ ������� ���� ��� �����:
                    FindObjectOfType<CardEffectManager>().SetPlayerEffectActive(card.CardEffect);
                    if(card.CardEffect.actionType==Effect.myActionTypes.deck)
                    {
                        SwitchCards(cardHolder.deck[0], card);
                        isSwitch = true;
                    }
                }
                break;
            case CardObject.myTypes.action_neg:
                //����� �������� �� ������� ����������
                interest -= card.Interest;
                attention -= card.Attention;
                nonsense += card.Nonsense;
                UpdateUI();
                break;
        }
        //������� ����� � ���� ���������
        Destroy(cardObject);
        print(index);
        if(!isSwitch)
        {
            cardHolder.hand[index] = null;
        }


        //��������� �������� ��� ������������ ���������
        CardGameEvent.NonsenseGained(nonsense);
        CardGameEvent.AttentionSpent(attention);
        //��������� �������� �� ����� �� ����, ���� ��� - ����� ������
        bool emptyHand = true;
        for (int i = 0; i < 6; i++)
        {
            if (cardHolder.hand[i] != null) { emptyHand = false; break; }
        }
        if(emptyHand & cardHolder.deck.Count==0)
        {
            print("����� ������");
            nextTurnBtn.interactable = false;
        }
    }

    public void TakeNewHand()
    {
        int deckSize = 0;
        for (int i = 0; i<6; i++)
        {
            if (cardHolder.hand[i]==null)
            {
                deckSize++;
            }
        }
        int deckTaken = 0;
        for (int i = 0; i<6; i++) 
        {
            if (deckSize>=i+1 & i<cardHolder.deck.Count)
            {
                TakeCard(cardHolder.deck[i]);
                deckTaken++;
            }
            else
            {
                break;
            }
        }
        for (int i = 0; i < deckTaken; i++)
        {
            cardHolder.deck.Remove(cardHolder.deck[0]);
        }
        UpdateUI();
    }

    //���� ��������� ��� ����� �������� ��� ����� � ����������� �����
    public void AddPoints(int attention, int interest, int nonsense)
    {
        this.attention -= attention;
        this.interest += interest;
        this.nonsense += nonsense;
        UpdateUI();
    }

    public void SubtractPoints(int attention, int interest, int nonsense)
    {
        this.attention += attention;
        this.interest -= interest;
        this.nonsense -= nonsense;
        UpdateUI();
    }

    [SerializeField] TextMeshProUGUI attentionUI;
    [SerializeField] TextMeshProUGUI interestUI;
    [SerializeField] TextMeshProUGUI nonsenseUI;
    public void UpdateUI()
    {
        attentionUI.text = attention.ToString();
        interestUI.text = interest.ToString();
        nonsenseUI.text = nonsense.ToString();
        deckCardsUI.text = cardHolder.deck.Count.ToString();
    }

}
