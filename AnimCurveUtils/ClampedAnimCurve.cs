using UnityEngine;

namespace LanKuDot.UnityToolBox.AnimCurveUtils
{
    public class ClampedAnimCurve
    {
        private readonly AnimationCurve _curve;
        private readonly float _minTime;
        private readonly float _maxTime;

        public float minTime => _minTime;
        public float maxTime => _maxTime;

        public ClampedAnimCurve(AnimationCurve curve)
        {
            _curve = curve;
            _minTime = _curve[0].time;
            _maxTime = _curve[_curve.length - 1].time;
        }

        /// <summary>
        /// Evaluate the animation curve within the time period specified in the curve
        /// </summary>
        /// <param name="time">The time, which will be clamped in the time range</param>
        /// <returns>The value evaluated in the range of the curve</returns>
        public float Evaluate(float time)
        {
            return _curve.Evaluate(Mathf.Clamp(time, _minTime, _maxTime));
        }
    }
}
