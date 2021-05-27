using UnityEngine;

namespace LanKuDot.UnityToolBox.System
{
    public class FPSLimiter : MonoBehaviour
    {
        [SerializeField]
        private int _fps = 60;

        private void Start()
        {
            Application.targetFrameRate = _fps;
        }
    }
}
