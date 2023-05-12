using System;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Demicus.Code.Infrastructure.Services.SceneContext
{
    public class SceneContextComponent : MonoBehaviour
    {

        private ISceneContextService _sceneContextService;

        [Inject]
        private void Construct(ISceneContextService sceneContextService)
        {
            _sceneContextService = sceneContextService;
            InitSceneContext();
        }

        private void InitSceneContext()
        {
        }
    }
}