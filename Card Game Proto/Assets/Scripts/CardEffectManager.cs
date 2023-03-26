using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardEffectManager : MonoBehaviour
{
    [SerializeField] public List<EffectHolder> PlayerEffects;
    CardManager cardManager;
    public GameObject playerIconPanel;
    public GameObject opponentIconPanel;
    public GameObject iconPrefab;
    Dictionary<EffectHolder, GameObject> icons = new Dictionary<EffectHolder, GameObject>();
    private void Start()
    {
        cardManager = FindObjectOfType<CardManager>();
    }

    public void SetPlayerEffectActive(Effect effect)
    {
        foreach(EffectHolder p in PlayerEffects) 
        {
            if(p.effect==effect & p.actionType != Effect.myActionTypes.deck)
            {
                
                //Добавление иконки эффекта на панель
                if (!p.active)
                {
                    SetIcon(p);
                }
                if (p.active)
                {
                    //p.maxTime+=p.effect.time; //если уже активирован эффект его продлеваем
                    p.time += p.effect.time;
                }
                else
                {
                    p.active = true;
                    p.time=p.maxTime;
                }

                break;
            }
        }
    }

    private void SetIcon(EffectHolder effectData)
    {
        GameObject newIcon = Instantiate(iconPrefab);
        newIcon.transform.SetParent(playerIconPanel.transform);
        newIcon.transform.localScale = Vector3.one;
        newIcon.GetComponent<Image>().sprite = effectData.icon;


        icons.Add(effectData, newIcon);
    }

    private void SetIcon(EffectHolder effectData, bool opponentEffect)
    {
        //эффекты которые стакаются на противника
    }

    public void PlayEffects(Effect.myTimeTypes timeType)
    {
        foreach (EffectHolder effect in PlayerEffects)
        {
            if (effect.active & effect.timeType == timeType)
            {
                switch (effect.actionType)
                {
                    case Effect.myActionTypes.interest:
                        cardManager.interest += effect.value;
                        print("Вам добавили интереса");
                        break;
                    case Effect.myActionTypes.attention:
                        cardManager.attention += effect.value;
                        print("Вам добавили внимания");
                        break;
                    case Effect.myActionTypes.deck:
                        break;

                }
                effect.time -= 1;
                if (effect.time == 0)
                {
                    effect.time = effect.maxTime;
                    effect.active = false;
                    Destroy(icons[effect]);
                    icons.Remove(effect);
                }
            }
        }

    }
}
