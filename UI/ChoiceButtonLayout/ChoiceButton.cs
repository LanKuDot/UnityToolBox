using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CommonToolBox.UI
{
    /// <summary>
    /// The button for choice
    /// </summary>
    [RequireComponent(typeof(Button))]
    public class ChoiceButton : AbstractLayoutItem
    {
        protected Button button;

        private void Awake()
        {
            button = GetComponent<Button>();
        }

        public override void Initialize(int id, object data)
        {
            Debug.Log($"id: {id}, data: {data}");
        }

        /// <summary>
        /// Register a callback to the onClick event of button
        /// </summary>
        /// <param name="callback">The callback</param>
        public void RegisterOnClick(UnityAction callback)
        {
            button.onClick.AddListener(callback);
        }

        /// <summary>
        /// Activate the button
        /// </summary>
        public void Activate()
        {
            button.enabled = true;
        }

        /// <summary>
        /// Inactivate the button
        /// </summary>
        public void Inactivate()
        {
            button.enabled = false;
        }
    }
}
