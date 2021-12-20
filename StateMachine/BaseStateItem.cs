namespace LanKuDot.UnityToolBox.StateMachine
{
    /// <summary>
    /// The basic component of the stage state
    /// </summary>
    public abstract class BaseStateItem<TStateEnum>
        where TStateEnum : BaseStateEnumeration
    {
        public TStateEnum targetState { get; }

        /// <summary>
        /// The basic item of the stage state
        /// </summary>
        /// <param name="targetState">The target state of this state item</param>
        protected BaseStateItem(TStateEnum targetState)
        {
            this.targetState = targetState;
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
