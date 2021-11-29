using System;
using System.Collections.Generic;

namespace LanKuDot.UnityToolBox.System.StageState
{
    /// <summary>
    /// Control the transition between states
    /// </summary>
    public abstract class BaseStateMachine<TStateEnum, TStateItem>
        where TStateEnum : BaseStateEnumeration
        where TStateItem : BaseStateItem<TStateEnum>
    {
        /// <summary>
        /// The dictionary for storing the mapping of state to state item
        /// </summary>
        private readonly Dictionary<TStateEnum, TStateItem> _states;
        /// <summary>
        /// The current state item
        /// </summary>
        private TStateItem _curStateItem;
        /// <summary>
        /// The current state enum
        /// </summary>
        private TStateEnum _curState;

        public event Action<TStateEnum, TStateEnum> onStateChanged;

        public BaseStateMachine(TStateItem[] stateItems)
        {
            _states = new Dictionary<TStateEnum, TStateItem>();
            RegisterState(stateItems);
        }

        /// <summary>
        /// Register the state item to the that state
        /// </summary>
        /// <param name="stateItems">The state items to be registered</param>
        private void RegisterState(TStateItem[] stateItems)
        {
            foreach (var item in stateItems)
                _states[item.targetState] = item;
        }

        /// <summary>
        /// Start the state machine
        /// </summary>
        public void StartMachine(TStateEnum startState)
        {
            _curState =
                startState ?? throw new NullReferenceException(nameof(startState));
            _curStateItem = _states[_curState];
            _curStateItem.OnStart();

            if (_curStateItem.autoTransitionState != null)
                NextState(_curStateItem.autoTransitionState);
        }

        /// <summary>
        /// Switch to the next state
        /// </summary>
        public void NextState(TStateEnum nextState)
        {
            if (_curState == null)
                return;

            StateTransition(nextState);
        }

        private void StateTransition(TStateEnum nextState)
        {
            var lastState = _curState;

            _curStateItem.OnEnd();

            _curState = nextState;
            if (_curState != null) {
                _curStateItem = _states[_curState];
                _curStateItem.OnStart();
            }

            onStateChanged?.Invoke(lastState, _curState);

            if (_curState != null && _curStateItem.autoTransitionState != null)
                NextState(_curStateItem.autoTransitionState);
        }
    }
}
