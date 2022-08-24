using UnityEngine;

namespace LanKuDot.UnityToolBox.UI.Utils
{
    public class CanvasSafeArea : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Whether to ignore the top of the safe area or not")]
        private bool _alignAtTop;
        [SerializeField]
        [Tooltip("Whether to ignore the bottom of the safe area or not")]
        private bool _alignAtBottom;

        private void Awake()
        {
            var panel = GetComponent<RectTransform>();
            var area = Screen.safeArea;

            var anchorMin = area.position;
            var anchorMax = area.position + area.size;
            anchorMin.x /= Screen.width;
            anchorMin.y /= Screen.height;
            anchorMax.x /= Screen.width;
            anchorMax.y /= Screen.height;

            panel.anchorMin = new Vector2(
                anchorMin.x,
                _alignAtBottom ? panel.anchorMin.y : anchorMin.y
            );
            panel.anchorMax = new Vector2(
                anchorMax.x,
                _alignAtTop ? panel.anchorMax.y : anchorMax.y
            );
        }
    }
}
