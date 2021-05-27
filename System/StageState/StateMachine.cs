using System.Collections;
using UnityEngine;

namespace LanKuDot.UnityToolBox.System.StageState
{
    /// <summary>
    /// Control the transition between states
    /// </summary>
    public sealed class StateMachine<T> where T : MonoBehaviour
    {
        /// <summary>
        /// The manager providing the main functions
        /// </summary>
        private readonly T _gamePlayManager;
        /// <summary>
        /// The current state
        /// </summary>
        private State<T> _curState;

        public StateMachine(T gamePlayManager)
        {
            _gamePlayManager = gamePlayManager;
        }

        /// <summary>
        /// Start the state machine
        /// </summary>
        public void StartMachine(State<T> startState)
        {
            _curState = startState;
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
