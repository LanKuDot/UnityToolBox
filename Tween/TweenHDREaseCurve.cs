using System;
using UnityEngine;

namespace LanKuDot.UnityToolBox.Tween
{
    [Serializable]
    public class TweenHDREaseCurve
    {
        [SerializeField]
        [Tooltip("The ease curve")]
        private AnimationCurve _curve;
        [SerializeField]
        [Tooltip("The duration of this ease curve")]
        private float _duration;
        [SerializeField]
        [ColorUsage(true, true)]
        [Tooltip("The end value of the tween")]
        private Color _endValue;
        [SerializeField]
        [Tooltip("Whether to use the start value or not")]
        private bool _useStartValue;
        [SerializeField]
        [ColorUsage(true, true)]
        [Tooltip("The start value of the tween")]
        private Color _startValue;

        public AnimationCurve curve => _curve;
        public float duration => _duration;
        public Color endValue => _endValue;
        public bool useStartValue => _useStartValue;
        public Color startValue => _startValue;
    }
}
