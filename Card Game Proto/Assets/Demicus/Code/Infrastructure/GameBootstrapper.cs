using Demicus.Code.Infrastructure.StateMachine;
using Demicus.Code.Infrastructure.StateMachine.States;
using UnityEngine;
using Zenject;

namespace Demicus.Code.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        private IGameStateMachine _gameStateMachine;

        [Inject]
        private void Construct(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        private void Start()
        {
            _gameStateMachine.Enter<BootstrapState>();
        }
    }
}