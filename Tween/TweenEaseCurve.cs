using System;
using UnityEngine;

namespace LanKuDot.UnityToolBox.Tween
{
    /// <summary>
    /// The ease curve for a tween
    /// </summary>
    [Serializable]
    public class TweenEaseCurve<T>
    {
        [SerializeField]
        [Tooltip("The ease curve")]
        private AnimationCurve _curve;
        [SerializeField]
        [Tooltip("The duration of this ease curve")]
        private float _duration;
        [SerializeField]
        [Tooltip("The end value of the tween")]
        private T _endValue;
        [SerializeField]
        [Tooltip("Whether to use the start value or not")]
        private bool _useStartValue;
        [SerializeField]
        [Tooltip("The start value of the tween")]
        private T _startValue;

        public AnimationCurve curve => _curve;
        public float duration => _duration;
        public T endValue => _endValue;
        public bool useStartValue => _useStartValue;
        public T startValue => _startValue;
    }
}
