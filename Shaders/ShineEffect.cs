using DG.Tweening;
using LanKuDot.UnityToolBox.Tween;
using UnityEngine;

namespace LanKuDot.UnityToolBox.Shaders
{
    public class ShineEffect : MonoBehaviour
    {
        [SerializeField]
        private Renderer[] _renderers;
        [SerializeField]
        [ColorUsage(true, true)]
        private Color _startColor;
        [SerializeField]
        private TweenHDREaseCurve _shineCurve;

        private MaterialPropertyBlock _materialProperty;
        private readonly int _emissionColor = Shader.PropertyToID("_EmissionColor");
        private Color _color;

        private void Awake()
        {
            _materialProperty ??= new MaterialPropertyBlock();
            foreach (var renderer in _renderers)
                foreach (var material in renderer.materials)
                    material.EnableKeyword("_EMISSION");
        }

        public void Shine()
        {
            _color = _startColor;
            DOTween.To(
                    () => _color, x => _color = x,
                    _shineCurve.endValue, _shineCurve.duration)
                .OnUpdate(UpdateMaterialColor)
                .SetUpdate(UpdateType.Normal)
                .SetEase(_shineCurve.curve);
        }

        private void UpdateMaterialColor()
        {
            _materialProperty.SetColor(_emissionColor, _color);
            foreach (var renderer in _renderers)
                renderer.SetPropertyBlock(_materialProperty);
        }
    }
}
