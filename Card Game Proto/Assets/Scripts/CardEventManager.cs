using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CardEventManager : MonoBehaviour
{
    CardManager cardManager;
    CardHolder cardHolder;

    [SerializeField] TextMeshProUGUI endingStatus;
    [SerializeField] TextMeshProUGUI endingDescription;
    [SerializeField] GameObject UICanvas;
    void Start()
    {
        cardManager = FindObjectOfType<CardManager>();
        cardHolder = FindObjectOfType<CardHolder>();
        for(int i = 0; i<6; i++)
        {
            cardManager.TakeCard(cardHolder.deck[i]);
        }
        for (int i = 0; i < 6; i++)
        {
            cardHolder.deck.RemoveAt(0);
        }
        cardManager.UpdateUI();
        CardGameEvent.OnNonsenseGained += GameOver_Nonsense;
        CardGameEvent.OnAttentionSpent += GameOver_Attention;
    }

    public void GameOver_Nonsense(int nonCount)
    {
        if(nonCount>=12)
        {
            EndingUI(false, "��� ����������� � ������. ����� �������� ������� ������, � ��� �������� �������� ��� �� ���� ���������.");
        }
    }
    public void GameOver_Attention(int atCount)
    {
        if (atCount<=0)
        {
            EndingUI(false, "��� ����������� � ������. ����� �������� ������� ������, � ��� �������� �������� ��� �� ���� ���������.");
        }
    }

    public void EndGame()
    {
        //�������� ����� �������� � ������ ����������� ����
        switch (cardManager.interest+cardManager.storyPoints)
        {
            case < 3:
                EndingUI(true, "����� ��������, �� ��� �� ����� ���������. �� ������ �� ����� � ����.");
                break;
            case < 5:
                EndingUI(true, "�� ������ ����� �����. ����� ����� ���� ������ �������, �� �� ���� ���.");
                break;
            case > 5:
                EndingUI(true, "����� ��� ���������� � ������� ������ �� ��������. ����� ��� ����� ������.");
                break;
        }
        print("������� ��������");
    }

    public void EndTurn()
    {
        print("����� ����");
        //��������� �������� ������� ������� ��������� �� �����
        FindObjectOfType<CardEffectManager>().PlayEffects(Effect.myTimeTypes.per_turn);
        FindObjectOfType<OpponentManager>().MakeAMove();
    }

    public void EndingUI(bool endingStatus, string endingDescription)
    {
        UICanvas.SetActive(true);
        switch(endingStatus)
        {
            case true:
                this.endingStatus.text = "������!";
                break;
            case false:
                this.endingStatus.text = "���������!";
                break;
        }
        this.endingDescription.text = endingDescription;
    }

}
