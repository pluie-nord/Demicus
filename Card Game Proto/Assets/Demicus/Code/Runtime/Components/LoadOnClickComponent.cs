using Demicus.Code.Infrastructure.Data;
using Demicus.Code.Infrastructure.StateMachine;
using Demicus.Code.Infrastructure.StateMachine.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Demicus.Code.Runtime.Components
{
    public class LoadOnClickComponent : MonoBehaviour
    {
        [SerializeField] private SceneID _sceneToLoad;
        private IGameStateMachine _gameStateMachine;

        [Inject]
        private void Constructor(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }


        private void OnMouseDown()
        {
            _gameStateMachine.Enter<LoadLevelState, SceneID>(_sceneToLoad);
        }
    }
}

