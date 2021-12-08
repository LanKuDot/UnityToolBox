using UnityEngine;

namespace LanKuDot.UnityToolBox.StateMachine.Character
{
    public class CharacterStateItem : BaseStateItem<CharacterStateEnum>
    {
        public CharacterStateItem(
            CharacterStateEnum targetState, CharacterStateEnum autoTransitionState = null)
            : base(targetState, autoTransitionState)
        {
        }

        #region Update Functions

        public virtual void Update() {}
        public virtual void FixedUpdate() {}
        public virtual void LateUpdate() {}

        #endregion

        #region Physics Functions

        public virtual void OnCollisionEnter(Collision other) {}
        public virtual void OnCollisionStay(Collision other) {}
        public virtual void OnCollisionExit(Collision other) {}
        public virtual void OnTriggerEnter(Collider other) {}
        public virtual void OnTriggerStay(Collider other) {}
        public virtual void OnTriggerExit(Collider other) {}

        #endregion

    }
}
