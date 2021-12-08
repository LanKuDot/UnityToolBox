using UnityEngine;

namespace LanKuDot.UnityToolBox.StateMachine.Character
{
    public class CharacterStateMachine
        : BaseStateMachine<CharacterStateEnum, CharacterStateItem>
    {
        public CharacterStateMachine(CharacterStateItem[] stateItems) : base(stateItems)
        {
        }

        #region Update Functions

        public void Update() => curStateItem.Update();
        public void FixedUpdate() => curStateItem.FixedUpdate();
        public void LateUpdate() => curStateItem.LateUpdate();

        #endregion

        #region Physics Functions

        public void OnCollisionEnter(Collision other) =>
            curStateItem.OnCollisionEnter(other);
        public void OnCollisionStay(Collision other) =>
            curStateItem.OnCollisionStay(other);
        public void OnCollisionExit(Collision other) =>
            curStateItem.OnCollisionExit(other);
        public void OnTriggerEnter(Collider other) =>
            curStateItem.OnTriggerEnter(other);
        public void OnTriggerStay(Collider other) =>
            curStateItem.OnTriggerStay(other);
        public void OnTriggerExit(Collider other) =>
            curStateItem.OnTriggerExit(other);

        #endregion
    }
}
