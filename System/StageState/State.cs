using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

namespace LanKuDot.UnityToolBox.System.StageState
{
    /// <summary>
    /// The basic component of the stage state
    /// </summary>
    public abstract class State<TManager, TStateEnum>
        where TManager : MonoBehaviour
        where TStateEnum : Enum
    {
        protected readonly TManager manager;

        protected State(TManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Things to do when the state starts
        /// </summary>
        public virtual IEnumerator OnStart()
        {
            yield break;
        }

        /// <summary>
        /// Things to do when the state ends
        /// </summary>
        public virtual IEnumerator OnEnd()
        {
            yield break;
        }

        /// <summary>
        /// Get the next state of this state
        /// </summary>
        /// <returns>The next state</returns>
        [CanBeNull]
        public abstract TStateEnum GetNextState();
    }
}
