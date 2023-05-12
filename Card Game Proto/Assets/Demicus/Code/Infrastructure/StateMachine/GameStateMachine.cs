using System;
using System.Collections.Generic;
using Demicus.Code.Infrastructure.StateMachine.States;
using Zenject;

namespace Demicus.Code.Infrastructure.StateMachine
{
    public class GameStateMachine : IGameStateMachine
    {
        private readonly Dictionary<Type, IInitializableState> _states;

        [Inject]
        public GameStateMachine(BootstrapState bootstrapState, LoadMainMenuState loadMainMenuState,
            LoadLevelState loadLevelState, GameLoopState gameLoopState)
        {
            _states = new Dictionary<Type, IInitializableState>
            {
                [typeof(BootstrapState)] = bootstrapState,
                [typeof(LoadMainMenuState)] = loadMainMenuState,
                [typeof(LoadLevelState)] = loadLevelState,
                [typeof(GameLoopState)] = gameLoopState,
            };

            foreach (var state in _states.Values)
            {
                state.SetupStateMachine(this);
            }
        }

        public IExitableState ActiveState { get; private set; }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            var state = ChangeState<TState>();
            state.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            ActiveState?.Exit(); 

            var state = GetState<TState>();
            ActiveState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState
        {
            return _states[typeof(TState)] as TState;
        }

        public void CleanUp()
        {
            ActiveState = null;
            _states.Clear();
        }
    }
}