using LanKuDot.UnityToolBox.Math;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace ToolBox.Editor
{
    [CustomPropertyDrawer(typeof(MinMaxValue))]
    public class MinMaxValueEditor : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var container = new VisualElement();
            container.style.flexDirection =
                new StyleEnum<FlexDirection>(FlexDirection.Row);

            var minField = new PropertyField(property.FindPropertyRelative("_min"));
            var maxField = new PropertyField(property.FindPropertyRelative("_max"));

            container.Add(minField);
            container.Add(maxField);

            return container;
        }

        public override void OnGUI(
            Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            var space = 4;
            var labelWidth = EditorGUIUtility.labelWidth;
            var fieldWidth = (position.width - labelWidth) / 2;
            var labelRect =
                new Rect(
                    position.x, position.y,
                    labelWidth, position.height);
            var minFieldRect =
                new Rect(
                    position.x + labelWidth + space, position.y,
                    fieldWidth - space, position.height);
            var maxFieldRect =
                new Rect(
                    position.x + labelWidth + fieldWidth + space, position.y,
                    fieldWidth - space, position.height);

            EditorGUI.LabelField(labelRect, label);

            var originIndentLevel = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            EditorGUIUtility.labelWidth = 30;
            EditorGUI.PropertyField(
                minFieldRect, property.FindPropertyRelative("_min"));
            EditorGUI.PropertyField(
                maxFieldRect, property.FindPropertyRelative("_max"));
            EditorGUIUtility.labelWidth = 0;

            EditorGUI.indentLevel = originIndentLevel;

            EditorGUI.EndProperty();
        }
    }
}
