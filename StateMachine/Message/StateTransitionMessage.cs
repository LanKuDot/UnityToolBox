namespace LanKuDot.UnityToolBox.StateMachine.Message
{
    public struct StateTransitionMessage<T>
        where T : BaseStateEnumeration
    {
        public T nextState;
    }
}
