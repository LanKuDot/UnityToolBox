using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace LanKuDot.UnityToolBox.System.StageState
{
    /// <summary>
    /// Control the transition between states
    /// </summary>
    public class StateMachine<TManager, TStateEnum>
        where TManager : MonoBehaviour
        where TStateEnum : Enum
    {
        /// <summary>
        /// The manager providing the main functions
        /// </summary>
        private readonly TManager _manager;
        /// <summary>
        /// The dictionary for storing the mapping of state to state item
        /// </summary>
        private readonly Dictionary<TStateEnum, State<TManager, TStateEnum>> _states;
        /// <summary>
        /// The current state item
        /// </summary>
        private State<TManager, TStateEnum> _curStateItem;
        /// <summary>
        /// The current state enum
        /// </summary>
        [CanBeNull]
        private TStateEnum _curStateEnum;

        public event Action<TStateEnum, TStateEnum> onStateChanged;

        public StateMachine(TManager manager)
        {
            _manager = manager;
            _states = new Dictionary<TStateEnum, State<TManager, TStateEnum>>();
        }

        /// <summary>
        /// Register the state item to the that state
        /// </summary>
        /// <param name="stateItem">The state item</param>
        /// <param name="atState">The corresponding state</param>
        public void RegisterState(
            State<TManager, TStateEnum> stateItem, TStateEnum atState)
        {
            _states[atState] = stateItem;
        }

        /// <summary>
        /// Start the state machine
        /// </summary>
        public void StartMachine(TStateEnum startState)
        {
            if (startState == null)
                throw new ArgumentNullException(nameof(startState));

            _curStateEnum = startState;
            _curStateItem = _states[_curStateEnum];
            _manager.StartCoroutine(_curStateItem.OnStart());
        }

        /// <summary>
        /// Switch to the next state
        /// </summary>
        public void NextState()
        {
            if (_curStateEnum == null)
                return;

            _manager.StartCoroutine(StateTransition());
        }

        private IEnumerator StateTransition()
        {
            var lastStateEnum = _curStateEnum;

            yield return _curStateItem.OnEnd();
            _curStateEnum = _curStateItem.GetNextState();
            if (_curStateEnum != null) {
                _curStateItem = _states[_curStateEnum];
                yield return _curStateItem.OnStart();
            }

            onStateChanged?.Invoke(lastStateEnum, _curStateEnum);
        }
    }
}
