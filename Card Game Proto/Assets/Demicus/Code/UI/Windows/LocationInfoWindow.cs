using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Demicus.Code.Infrastructure.Data;
using Demicus.Code.Runtime.Components;
using UnityEngine.UI;
using Demicus.Code.Infrastructure.Services.UIFactory;
using Zenject;
using Demicus.Code.Infrastructure.StateMachine;
using Demicus.Code.Infrastructure.StateMachine.States;

public class LocationInfoWindow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private Button _closeButton;
    [SerializeField] private Button _continueButton;

    public ShopInfoComponent shopInfo;

    private SceneID _sceneToLoad;

    private IGameStateMachine _gameStateMachine;    
    private IUIFactory _UIFactory;

    [Inject]
    private void Constructor(IUIFactory UIFactory, IGameStateMachine gameStateMachine)
    {
        _UIFactory = UIFactory;
        _gameStateMachine = gameStateMachine;
    }
    
    private void Awake()
    {
        Subscribe();
    }
    private void Subscribe()
    {
        _closeButton.onClick.AddListener(Close);
        _continueButton.onClick.AddListener(Continue);
    }

    private void Unsubscribe()
    {
        _closeButton.onClick.RemoveListener(Close);
        _continueButton.onClick.RemoveListener(Continue);
    }

    public void SetSceneInfo(LocationInfoComponent locationInfo)
    {
        _name.text = locationInfo._name;
        _description.text = locationInfo._descriprion;
        _sceneToLoad = locationInfo._sceneToLoad;
    }

    private void Close()
    {
        _UIFactory.ClearUIRoot();
    }

    private void Continue()
    {
        GameObject location = _UIFactory.CreateWindow(WindowID.Shop);
        location.GetComponent<ShopWIndow>().SetInfo(shopInfo.shopType, shopInfo.shopSprite, shopInfo.shopOwnerSprite, shopInfo.shopItems);
    }

    private void OnDestroy()
    {
        Unsubscribe();
    }
}
