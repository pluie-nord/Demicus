using Demicus.Code.Infrastructure.Data;
using UnityEngine;
using Zenject;
using Demicus.Code.Infrastructure.Services.UIFactory;
using Demicus.Code.Runtime.Components;

namespace Demicus.Code.Runtime.Map
{
    [RequireComponent(typeof (LocationInfoComponent))]
    public class MapAction : MonoBehaviour
    {
        private IUIFactory _UIFactory;

        [Inject]
        private void Constructor(IUIFactory UIFactory)
        {
            _UIFactory = UIFactory;
        }

        private void OnMouseDown()
        {
            _UIFactory.ClearUIRoot();
            GameObject UIWindow = _UIFactory.CreateWindow(WindowID.LocationInfo);
            UIWindow.GetComponent<LocationInfoWindow>().SetSceneInfo(GetComponent<LocationInfoComponent>());
            UIWindow.GetComponent<LocationInfoWindow>().shopInfo = GetComponent<ShopInfoComponent>();
        }
    }
}

