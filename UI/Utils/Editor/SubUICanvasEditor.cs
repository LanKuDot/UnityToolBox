#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace LanKuDot.UnityToolBox.UI.Utils.Editor
{
    [CustomEditor(typeof(SubUICanvas))]
    public class SubUICanvasEditor : UnityEditor.Editor
    {
        private bool _previousActivateValue;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            ToggleComponent();
        }

        private void ToggleComponent()
        {
            var activateProperty = serializedObject.FindProperty("_defaultToActive");
            var value = activateProperty.boolValue;

            if (_previousActivateValue == value)
                return;

            var canvas =
                serializedObject.FindProperty("_canvas").objectReferenceValue as Canvas;
            var raycaster =
                serializedObject.FindProperty("_raycaster").objectReferenceValue as
                    GraphicRaycaster;

            if (canvas && canvas.enabled != value)
                canvas.enabled = value;
            if (raycaster && raycaster.enabled != value)
                raycaster.enabled = value;

            _previousActivateValue = value;
        }
    }
}

#endif
