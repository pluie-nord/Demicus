using CrushLink.Code.Infrastructure.Services.UpdateBehaviorService;
using Demicus.Code.Infrastructure.Services.AssetProvider;
using Demicus.Code.Infrastructure.Services.CoroutineRunner;
using Demicus.Code.Infrastructure.Services.SaveLoadService;
using Demicus.Code.Infrastructure.Services.SceneContext;
using Demicus.Code.Infrastructure.Services.SceneLoaderService;
using Demicus.Code.Infrastructure.Services.StaticData;
using Demicus.Code.Infrastructure.Services.UIFactory;
using Demicus.Code.Infrastructure.Services.ZenjectFactory;
using Demicus.Code.Infrastructure.StateMachine.States;
using Demicus.Code.Infrastructure.StateMachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Demicus.Code.Infrastructure.DI
{
    public class ProjectContextInstaller : MonoInstaller, ICoroutineRunner
    {
        [SerializeField] private UpdateBehaviour _updateBehaviour;
        [SerializeField] private SceneLoader _sceneLoader;
        public override void InstallBindings()
        {
            BindServices();
            BindFactories();
            BindGameStateMachine();
        }

        private void BindServices()
        {
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
            Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
            Container.Bind<ISceneContextService>().To<SceneContextService>().AsSingle();
            Container.Bind<ICoroutineRunner>().FromInstance(this).AsSingle();
            Container.Bind<ISaveLoadService>().To<SaveLoadService>().AsSingle();
            Container.Bind<IPersistentProgressService>().To<PersistentProgressService>().AsSingle();
            Container.Bind<IUpdateBehaviourService>().FromInstance(_updateBehaviour).AsSingle();
            Container.Bind<ISceneLoader>().FromInstance(_sceneLoader).AsSingle();
        }

        private void BindGameStateMachine()
        {
            Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle();
            Container.Bind<BootstrapState>().To<BootstrapState>().AsSingle();
            Container.Bind<LoadMainMenuState>().To<LoadMainMenuState>().AsSingle();
            Container.Bind<LoadLevelState>().To<LoadLevelState>().AsSingle();
            Container.Bind<GameLoopState>().To<GameLoopState>().AsSingle();
        }

        private void BindFactories()
        {
            Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();
            Container.Bind<IZenjectFactory>().To<ZenjectFactory>().AsSingle();
        }
    }
}

