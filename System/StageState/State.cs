using System.Collections;

namespace CommonToolBox.StageState
{
    /// <summary>
    /// The basic component of the stage state
    /// </summary>
    public abstract class State
    {
        protected readonly GamePlayManager gamePlayManager;

        protected State(GamePlayManager gamePlayManager)
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
        public virtual State GetNextState()
        {
            return null;
        }
    }
}
