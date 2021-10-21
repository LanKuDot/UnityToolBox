using System;
using UnityEngine;

namespace LanKuDot.UnityToolBox
{
    /// <summary>
    /// The ease curve for a tween
    /// </summary>
    [Serializable]
    public class TweenEaseCurve
    {
        [SerializeField]
        [Tooltip("The ease curve")]
        private AnimationCurve _curve;
        [SerializeField]
        [Tooltip("The duration of this ease curve")]
        private float _duration;

        public AnimationCurve curve => _curve;
        public float duration => _duration;
    }
}
