using System;
using System.Collections.Generic;

namespace LanKuDot.UnityToolBox.StateMachine
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
        protected TStateItem curStateItem { get; private set; }
        /// <summary>
        /// The current state enum
        /// </summary>
        protected TStateEnum curState { get; private set; }

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
            curState =
                startState ?? throw new NullReferenceException(nameof(startState));
            curStateItem = _states[curState];
            curStateItem.OnStart();

            if (curStateItem.autoTransitionState != null)
                NextState(curStateItem.autoTransitionState);
        }

        /// <summary>
        /// Switch to the next state
        /// </summary>
        public void NextState(TStateEnum nextState)
        {
            if (curState == null)
                return;

            StateTransition(nextState);
        }

        private void StateTransition(TStateEnum nextState)
        {
            var lastState = curState;

            curStateItem.OnEnd();

            curState = nextState;
            if (curState != null) {
                curStateItem = _states[curState];
                curStateItem.OnStart();
            }

            onStateChanged?.Invoke(lastState, curState);

            if (curState != null && curStateItem.autoTransitionState != null)
                NextState(curStateItem.autoTransitionState);
        }
    }
}
