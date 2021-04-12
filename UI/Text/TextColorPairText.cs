using System;
using TMPro;
using UnityEngine;

namespace GamePlay.UI
{
    /// <summary>
    /// Display the text and related color
    /// </summary>
    public class TectColorPairText : MonoBehaviour
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
