using UnityEngine;

namespace LanKuDot.UnityToolBox.Math
{
    public class AnimationCurveHelper
    {
        private readonly AnimationCurve _curve;
        private readonly float _minTime;
        private readonly float _maxTime;

        public AnimationCurveHelper(AnimationCurve curve)
        {
            _curve = curve;
            _minTime = _curve[0].time;
            _maxTime = _curve[_curve.length - 1].time;
        }

        /// <summary>
        /// Evaluate the animation curve within the time period specified in the curve
        /// </summary>
        /// <param name="time">The time</param>
        /// <returns>The value evaluated in the range of the curve</returns>
        public float EvaluateClamped(float time)
        {
            return _curve.Evaluate(Mathf.Clamp(time, _minTime, _maxTime));
        }
    }
}
