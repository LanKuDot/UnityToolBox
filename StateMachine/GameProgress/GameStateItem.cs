using UnityEngine;

namespace LanKuDot.UnityToolBox.StateMachine.GameProgress
{
    public class GameStateItem : BaseStateItem<GameStateEnum>
    {
        public GameStateItem(
            GameStateEnum targetState, GameStateEnum autoTransitionState = null)
            : base(targetState, autoTransitionState)
        {
        }
    }
}
