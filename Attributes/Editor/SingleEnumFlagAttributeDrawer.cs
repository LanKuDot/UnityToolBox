#if UNITY_EDITOR

using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace LanKuDot.UnityToolBox.Attributes.Editor
{
    [CustomPropertyDrawer(typeof(SingleEnumFlagAttribute))]
    public class SingleEnumFlagAttributeDrawer : PropertyDrawer
    {
        public override void OnGUI(
            Rect position, SerializedProperty property, GUIContent label)
        {
            var singleEnumFlagAttr = (SingleEnumFlagAttribute)attribute;
            if (!singleEnumFlagAttr.IsValid)
                return;

            var texts = new List<GUIContent>();
            var enumValues = new List<int>();

            foreach (var enumValue in Enum.GetValues(singleEnumFlagAttr.EnumType)) {
                texts.Add(new GUIContent(enumValue.ToString()));
                enumValues.Add((int)enumValue);
            }

            property.intValue =
                EditorGUI.IntPopup(
                    position, label, property.intValue,
                    texts.ToArray(), enumValues.ToArray());
        }
    }
}

#endif
