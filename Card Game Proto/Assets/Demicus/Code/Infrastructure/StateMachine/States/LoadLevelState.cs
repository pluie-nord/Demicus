using System;
using Demicus.Code.Infrastructure.Data;
using Demicus.Code.Infrastructure.Services.SceneContext;
using Demicus.Code.Infrastructure.Services.SceneLoaderService;
using Demicus.Code.Infrastructure.Services.StaticData;
using Demicus.Code.Infrastructure.Services.UIFactory;
using Demicus.Code.Infrastructure.StaticData;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Demicus.Code.Infrastructure.StateMachine.States
{
    public class LoadLevelState : IInitializableState, IPayloadedState<string>, IPayloadedState<SceneID>
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly IStaticDataService _staticDataService;
        private readonly ISceneContextService _sceneContext;
        private readonly IUIFactory _uiFactory;
        private IGameStateMachine _gameStateMachine;

        [Inject]
        public LoadLevelState(ISceneLoader sceneLoader,
            IStaticDataService staticDataService, ISceneContextService sceneContext, IUIFactory uiFactory)
        {
            _sceneLoader = sceneLoader;
            _staticDataService = staticDataService;
            _sceneContext = sceneContext;
            _uiFactory = uiFactory;
        }

        public void SetupStateMachine(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            _sceneLoader.LoadScene(SceneManager.GetActiveScene().name, OnLoaded);
        }

        public void Enter(SceneID levelID)
        {
            _sceneLoader.LoadScene(levelID, OnLoaded);
        }

        public void Enter(string levelID)
        {
#if !UNITY_EDITOR
            _sceneLoader.LoadScene(levelID, OnLoaded);
#endif
#if UNITY_EDITOR
            OnLoaded();
#endif
        }

        private void OnLoaded()
        {
            _uiFactory.ClearUIRoot();
            InitWinLose();

            _gameStateMachine.Enter<GameLoopState>();
        }

        private void InitWinLose()
        {
            /*if (_sceneContext.WinLoseTracker == null)
                return;

            _sceneContext.WinLoseTracker.Init();*/
        }

       

        public void Exit()
        {
        }
    }
}