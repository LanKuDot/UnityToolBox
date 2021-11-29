namespace LanKuDot.UnityToolBox.System.StageState
{
    /// <summary>
    /// The basic component of the stage state
    /// </summary>
    public abstract class BaseStateItem<TStateEnum>
        where TStateEnum : BaseStateEnumeration
    {
        public TStateEnum targetState { get; }
        public TStateEnum autoTransitionState { get; }

        /// <summary>
        /// The basic item of the stage state
        /// </summary>
        /// <param name="targetState">The target state of this state item</param>
        /// <param name="autoTransitionState">
        /// The state for transition automatically after this state item
        /// </param>
        protected BaseStateItem(
            TStateEnum targetState, TStateEnum autoTransitionState = null)
        {
            this.targetState = targetState;
            this.autoTransitionState = autoTransitionState;
        }

        /// <summary>
        /// Things to do when the state starts
        /// </summary>
        public virtual void OnStart()
        {
        }

        /// <summary>
        /// Things to do when the state ends
        /// </summary>
        public virtual void OnEnd()
        {
        }
    }
}
