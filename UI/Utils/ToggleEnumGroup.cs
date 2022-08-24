using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace LanKuDot.UnityToolBox.UI.Utils
{
    /// <summary>
    /// The toggle group for getting the enum of the checked toggles
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum</typeparam>
    [Serializable]
    public class ToggleEnumGroup<TEnum>
        where TEnum : Enum
    {
        [SerializeField]
        private ToggleEnum[] _toggleEnums;

        #region Public Functions

        /// <summary>
        /// Get the checked enums
        /// </summary>
        public IEnumerable<TEnum> GetCheckedEnums() =>
            _toggleEnums
                .Where(toggleEnum => toggleEnum.toggle.isOn)
                .Select(toggleEnum => toggleEnum.enumValue);

        /// <summary>
        /// Get the first checked enum
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// If there has no checked enum
        /// </exception>
        public TEnum GetFirstCheckedEnum() =>
            _toggleEnums.First(toggleEnum => toggleEnum.toggle.isOn).enumValue;

        /// <summary>
        /// Set a checked enum
        /// </summary>
        /// <param name="enum">The target enum to be set</param>
        /// <param name="clearOthers">Whether to clear the other toggles or not</param>
        public void SetCheckedEnum(TEnum @enum, bool clearOthers = false)
        {
            foreach (var toggleEnum in _toggleEnums) {
                if (toggleEnum.enumValue.Equals(@enum))
                    toggleEnum.toggle.isOn = true;
                else if (clearOthers)
                    toggleEnum.toggle.isOn = false;
            }
        }

        /// <summary>
        /// Set the checked enums
        /// </summary>
        /// <param name="enums">The enums to be set</param>
        /// <param name="clearOthers">Whether to clear the other toggles or not</param>
        public void SetCheckedEnums(TEnum[] enums, bool clearOthers = false)
        {
            foreach (var toggleEnum in _toggleEnums) {
                if (enums.Contains(toggleEnum.enumValue))
                    toggleEnum.toggle.isOn = true;
                else if (clearOthers)
                    toggleEnum.toggle.isOn = false;
            }
        }

        /// <summary>
        /// Set the checked enum by the flagged enum
        /// </summary>
        /// <param name="enum">The value of the flagged enum</param>
        /// <param name="clearOthers">Whether to clear the other toggles or not</param>
        public void SetCheckedEnumsByFlag(TEnum @enum, bool clearOthers = false)
        {
            var enums =
                Enum.GetValues(typeof(TEnum)).Cast<TEnum>()
                    .Where(enumValue => @enum.HasFlag(enumValue))
                    .ToArray();
            SetCheckedEnums(enums, clearOthers);
        }

        #endregion

        #region Sub Data Class

        [Serializable]
        public class ToggleEnum
        {
            [SerializeField]
            private TEnum _enumValue;
            [SerializeField]
            private Toggle _toggle;

            public TEnum enumValue => _enumValue;
            public Toggle toggle => _toggle;
        }

        #endregion
    }
}
