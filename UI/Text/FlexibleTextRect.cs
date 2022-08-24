using System.Collections;
using TMPro;
using UnityEngine;

namespace LanKuDot.UnityToolBox.UI.Text
{
    /// <summary>
    /// The component for controlling the size of the rect transform to fit the text
    /// </summary>
    [RequireComponent(typeof(RectTransform), typeof(TextMeshProUGUI))]
    public class FlexibleTextRect : MonoBehaviour
    {
        [SerializeField]
        private RectTransform _rectTransform;
        [SerializeField]
        private TextMeshProUGUI _text;

        [Header("Options")]
        [SerializeField]
        [Tooltip("Is the height flexible?")]
        private bool _flexibleHeight = true;
        [SerializeField]
        [Tooltip("Is the width flexible?")]
        private bool _flexibleWidth;

        private void Reset()
        {
            _rectTransform = GetComponent<RectTransform>();
            _text = GetComponent<TextMeshProUGUI>();
        }

        /// <summary>
        /// Make the rect to fit the size of the text
        /// </summary>
        /// Because of the characteristic of updating text mesh of the TMP,
        /// the size of rect is changed at the end of the frame.
        public void FitText(string text)
        {
            _text.text = text;
            StartCoroutine(FitTextCoroutine());
        }

        private IEnumerator FitTextCoroutine()
        {
            yield return new WaitForEndOfFrame();
            if (_flexibleHeight)
                _rectTransform.SetSizeWithCurrentAnchors(
                    RectTransform.Axis.Vertical, _text.preferredHeight);
            if (_flexibleWidth)
                _rectTransform.SetSizeWithCurrentAnchors(
                    RectTransform.Axis.Horizontal, _text.preferredWidth);
        }
    }
}
