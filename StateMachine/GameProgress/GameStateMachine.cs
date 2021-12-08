using UnityEngine;

namespace LanKuDot.UnityToolBox.StateMachine.GameProgress
{
    public class GameStateMachine : BaseStateMachine<GameStateEnum, GameStateItem>
    {
        public GameStateMachine(GameStateItem[] stateItems) : base(stateItems)
        {
        }
    }
}
