using Demicus.Code.Infrastructure.Services.UIFactory;
using Zenject;

namespace Demicus.Code.Infrastructure.StateMachine.States
{
    public class GameLoopState : IInitializableState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IUIFactory _uiFactory;
        private IGameStateMachine _gameStateMachine;

        [Inject]
        public GameLoopState(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        public void SetupStateMachine(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            //_playerInput.EnableEscapeButton();
        }

        public void Exit()
        {
            _uiFactory.ClearUIRoot();
        }
    }
}