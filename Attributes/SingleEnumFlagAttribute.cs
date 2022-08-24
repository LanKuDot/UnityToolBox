using System;
using UnityEngine;

namespace LanKuDot.UnityToolBox.Attributes
{
    /// <summary>
    /// The attribute to make the serialized field could only be set a single enum flag
    /// </summary>
    public class SingleEnumFlagAttribute : PropertyAttribute
    {
        private Type _enumType;
        /// <summary>
        /// The type of the enum
        /// </summary>
        public Type EnumType
        {
            get => _enumType;
            set {
                if (value is not { IsEnum: true }) {
                    Debug.LogError(
                        $"The 'EnumType' of '{GetType().Name} must be an enum");
                    return;
                }

                _enumType = value;
                IsValid = true;
            }
        }

        /// <summary>
        /// Is the stored value valid?
        /// </summary>
        public bool IsValid { get; private set; }
    }
}
