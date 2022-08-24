using UnityEngine;
using UnityEngine.UI;

namespace LanKuDot.UnityToolBox.UI.Utils
{
    /// <summary>
    /// The canvas for the sub ui
    /// </summary>
    [RequireComponent(typeof(Canvas), typeof(GraphicRaycaster))]
    public class SubUICanvas : MonoBehaviour
    {
        [HideInInspector]
        [SerializeField]
        private Canvas _canvas;
        [HideInInspector]
        [SerializeField]
        private GraphicRaycaster _raycaster;
        [SerializeField]
        [Tooltip("Whether to activate the sub canvas or not")]
        private bool _defaultToActive;

        public bool defaultToActive => _defaultToActive;

        private void Reset()
        {
            _canvas = GetComponent<Canvas>();
            _raycaster = GetComponent<GraphicRaycaster>();
            _defaultToActive = true;
        }

        /// <summary>
        /// Activate the sub ui canvas or not
        /// </summary>
        public void SetActive(bool active)
        {
            _canvas.enabled = _raycaster.enabled = active;
        }
    }
}
