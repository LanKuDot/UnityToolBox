using UnityEngine;

namespace LanKuDot.UnityToolBox.System
{
    public class AppControlSettings : MonoBehaviour
    {
        [SerializeField]
        private bool _backToLeave = true;
        [SerializeField]
        private bool _allowMultiTouch = true;

        private void Awake()
        {
            Input.backButtonLeavesApp = _backToLeave;
            Input.multiTouchEnabled = _allowMultiTouch;
        }
    }
}
