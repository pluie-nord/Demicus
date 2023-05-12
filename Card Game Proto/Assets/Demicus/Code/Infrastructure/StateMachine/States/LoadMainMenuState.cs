using System;
using System.Linq;
using Demicus.Code.Infrastructure.Data;
using Demicus.Code.Infrastructure.Services.SceneLoaderService;
using Demicus.Code.Infrastructure.Services.StaticData;
using Demicus.Code.Infrastructure.Services.UIFactory;
using UnityEngine.SceneManagement;
using Zenject;

namespace Demicus.Code.Infrastructure.StateMachine.States
{
    public class LoadMainMenuState : IInitializableState, IPayloadedState<bool>
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly IUIFactory _uiFactory;
        private readonly IStaticDataService _staticDataService;
        private IGameStateMachine _gameStateMachine;

        [Inject]
        public LoadMainMenuState(ISceneLoader sceneLoader, IUIFactory uiFactory, IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
            _uiFactory = uiFactory;
            _sceneLoader = sceneLoader;
        }

        public void SetupStateMachine(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter(bool payload)
        {
#if !UNITY_EDITOR
             _sceneLoader.LoadScene(SceneID.MainMenuScene, OnLoaded);
#endif
#if UNITY_EDITOR
            OnLoaded();
#endif
        }

        public void Enter()
        {
            //_sceneLoader.LoadScene(SceneID.MainMenuScene, OnLoaded);
        }

        private void OnLoaded()
        {
            //_uiFactory.CreateWindow(WindowID.MainMenu);

            ValidateGameComplete();
        }

        private void ValidateGameComplete()
        {
            SceneID[] SceneIds = (SceneID[])Enum.GetValues(typeof(SceneID));
            if (_staticDataService.LastCompleteLevel != SceneIds.Last()) 
                return;

            //_uiFactory.CreateWindow(WindowID.About);
            //_uiFactory.CreateWindow(WindowID.FinalComics);
            _staticDataService.SetLastCompleteLevel(null);
        }

        public void Exit()
        {
            //_uiFactory.ClearUIRoot();
        }
    }
}