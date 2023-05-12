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
            EndingUI(false, "Вас заподозрили в обмане. Гость грозился вызвать стражу, и вам пришлось угостить его за счет заведения.");
        }
    }
    public void GameOver_Attention(int atCount)
    {
        if (atCount<=0)
        {
            EndingUI(false, "Вас заподозрили в обмане. Гость грозился вызвать стражу, и вам пришлось угостить его за счет заведения.");
        }
    }

    public void EndGame()
    {
        //пересчет очков интереса с учетом соотношения карт
        switch (cardManager.interest+cardManager.storyPoints)
        {
            case < 3:
                EndingUI(true, "Гость дослушал, но ему не особо интересно. Он ничего не купил и ушел.");
                break;
            case < 5:
                EndingUI(true, "Ну ничего байка такая. Гость купил один стакан выпивки, но на этом все.");
                break;
            case > 5:
                EndingUI(true, "Гость вас заслушался и покупал стакан за стаканом. Домой его несли друзья.");
                break;
        }
        print("уровень завершен");
    }

    public void EndTurn()
    {
        print("Конец хода");
        //проверять активные эффекты которые действуют по ходам
        FindObjectOfType<CardEffectManager>().PlayEffects(Effect.myTimeTypes.per_turn);
        FindObjectOfType<OpponentManager>().MakeAMove();
    }

    public void EndingUI(bool endingStatus, string endingDescription)
    {
        UICanvas.SetActive(true);
        switch(endingStatus)
        {
            case true:
                this.endingStatus.text = "Победа!";
                break;
            case false:
                this.endingStatus.text = "Поражение!";
                break;
        }
        this.endingDescription.text = endingDescription;
    }

}
