using UnityEngine;

namespace LanKuDot.UnityToolBox.StateMachine.GameProgress
{
    public class GameStateItem : BaseStateItem<GameStateEnum>
    {
        public GameStateItem(GameStateEnum targetState)
            : base(targetState)
        {
        }
    }
}
