namespace LanKuDot.UnityToolBox.StateMachine.Character
{
    public class CharacterStateEnum : BaseStateEnumeration
    {
        public static CharacterStateEnum Init { get; } = new CharacterStateEnum();
        public static CharacterStateEnum Success { get; } = new CharacterStateEnum();
        public static CharacterStateEnum Fail { get; } = new CharacterStateEnum();
    }
}
