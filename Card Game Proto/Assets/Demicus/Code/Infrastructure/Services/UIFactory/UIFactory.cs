using Demicus.Code.Infrastructure.Data;
using Demicus.Code.Infrastructure.Services.StaticData;
using Demicus.Code.Infrastructure.Services.ZenjectFactory;
using Demicus.Code.Infrastructure.StaticData;
using UnityEngine;
using Zenject;

namespace Demicus.Code.Infrastructure.Services.UIFactory
{
    public class UIFactory : IUIFactory
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IZenjectFactory _zenjectFactory;
        private Transform _uiRoot;
        public Transform UIRootObject => _uiRoot;

        [Inject]
        public UIFactory(IStaticDataService staticDataService, IZenjectFactory zenjectFactory)
        {
            _zenjectFactory = zenjectFactory;
            _staticDataService = staticDataService;
        }
        
        public void CreateUiRoot()
        {
            if (_uiRoot != null)
                Object.Destroy(_uiRoot.gameObject);
            WindowConfig config = _staticDataService.GetWindow(WindowID.UiRoot);
            GameObject uiRoot = _zenjectFactory.Instantiate(config.Window.gameObject);
            uiRoot.transform.SetParent(null);
            _uiRoot = uiRoot.transform;
        }

        public GameObject CreateWindow(WindowID windowID)
        {
            WindowConfig config = _staticDataService.GetWindow(windowID);
            return _zenjectFactory.Instantiate(config.Window.gameObject, _uiRoot);
        }
        
        public T CreateWindow<T>(WindowID windowID) 
        {
            GameObject window = CreateWindow(windowID);
            return window.GetComponent<T>();
        }

        public void ClearUIRoot()
        {
            for (int i = 0; i < _uiRoot.childCount; i++) 
                Object.Destroy(_uiRoot.GetChild(i).gameObject);
        }
    }
}