using System.Collections;

namespace CommonToolBox.StageState
{
    /// <summary>
    /// Control the transition between states
    /// </summary>
    public sealed class StateMachine
    {
        /// <summary>
        /// The manager providing the main functions
        /// </summary>
        private readonly GamePlayManager _gamePlayManager;
        /// <summary>
        /// The current state
        /// </summary>
        private State _curState;

        public StateMachine(GamePlayManager gamePlayManager)
        {
            _gamePlayManager = gamePlayManager;
        }

        /// <summary>
        /// Start the state machine
        /// </summary>
        public void StartMachine()
        {
            _curState = new StageStartCase(_gamePlayManager);
            _gamePlayManager.StartCoroutine(_curState.OnStart());
        }

        /// <summary>
        /// Switch to the next state
        /// </summary>
        public void NextState()
        {
            if (_curState == null)
                return;

            _gamePlayManager.StartCoroutine(StateTransition());
        }

        private IEnumerator StateTransition()
        {
            yield return _curState.OnEnd();
            _curState = _curState.GetNextState();
            if (_curState != null)
                yield return _curState.OnStart();
        }
    }
}
