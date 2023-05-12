using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectHolder : MonoBehaviour
{
    public Effect effect;

    public Effect.myActionTypes actionType;
    public Effect.myTimeTypes timeType;
    public int value;
    public bool active;
    public int maxTime;
    public int time;
    public Sprite icon;
    private void Start()
    {
        this.actionType = effect.actionType;
        this.timeType = effect.timeType;
        this.active = effect.active;
        this.maxTime = effect.time;
        this.time = effect.time;
        this.value=effect.value;
        this.icon = effect.icon;
    }
}
