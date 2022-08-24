using UnityEngine.UI;

namespace LanKuDot.UnityToolBox.UI.Utils
{
    /// <summary>
    /// The helper class for managing the scroll rect
    /// </summary>
    public static class ScrollRectHelper
    {
        public static void ResetPos(ScrollRect scrollRect)
        {
            var contentPos = scrollRect.content.anchoredPosition;
            contentPos.y = 0;
            scrollRect.content.anchoredPosition = contentPos;
            scrollRect.StopMovement();
        }
    }
}
