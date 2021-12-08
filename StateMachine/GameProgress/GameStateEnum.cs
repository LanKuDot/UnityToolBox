using UnityEngine;

namespace LanKuDot.UnityToolBox.StateMachine.GameProgress
{
    public class GameStateEnum : BaseStateEnumeration
    {
        public static GameStateEnum Init { get; } = new GameStateEnum();
        public static GameStateEnum Play { get; } = new GameStateEnum();
        public static GameStateEnum Success { get; } = new GameStateEnum();
        public static GameStateEnum Fail { get; } = new GameStateEnum();
    }
}
