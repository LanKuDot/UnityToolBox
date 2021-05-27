using System.Collections;
using UnityEngine;

namespace LanKuDot.UnityToolBox.System.StageState
{
    /// <summary>
    /// The basic component of the stage state
    /// </summary>
    public abstract class State<T> where T : MonoBehaviour
    {
        protected readonly T gamePlayManager;

        protected State(T gamePlayManager)
        {
            this.gamePlayManager = gamePlayManager;
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
        public virtual State<T> GetNextState()
        {
            return null;
        }
    }
}
