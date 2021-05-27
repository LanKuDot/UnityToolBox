using System;
using TMPro;
using UnityEngine;

namespace LanKuDot.UnityToolBox.UI.Text
{
    /// <summary>
    /// Display the text and related color
    /// </summary>
    public class TextColorPairText : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _text;
        [SerializeField]
        private TextColorPair[] _textColorPairs;

        public void Show(int index)
        {
            _text.text = _textColorPairs[index].text;
            _text.color = _textColorPairs[index].color;
        }
    }

    [Serializable]
    public class TextColorPair
    {
        public string text;
        public Color color;
    }
}
