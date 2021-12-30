using System.Collections.Generic;
using LanKuDot.UnityToolBox.UI.PointerDetection;
using UnityEngine;
using UnityEngine.EventSystems;

namespace LanKuDot.UnityToolBox.ObjectManagement.Raycasting
{
    /// <summary>
    /// The manager that handling the targets to be hit by the ray
    /// </summary>
    public class RaycastTargetManager : MonoBehaviour
    {
        #region Serialize Fields

        [SerializeField]
        private PointerDetectionUI _pointerDetectionUI;
        [SerializeField]
        private Camera _camera;
        [SerializeField]
        [Tooltip("The targets to be hit by the ray")]
        private List<RaycastableObject> _targets;

        #endregion

        private Collider[] _targetColliders;
        private RaycastableObject _selectedObject;

        private void Awake()
        {
            ExtractColliders();
        }

        private void Start()
        {
            _pointerDetectionUI.onDragBegin += OnDragBegin;
            _pointerDetectionUI.onDragging += OnDragging;
            _pointerDetectionUI.onDragEnd += OnDragEnd;
        }

        /// <summary>
        /// Extract the colliders out of registered component
        /// </summary>
        private void ExtractColliders()
        {
            _targetColliders = new Collider[_targets.Count];
            for (var i = 0; i < _targets.Count; ++i)
                _targetColliders[i] = _targets[i].GetComponent<Collider>();
        }

        /// <summary>
        /// Get the hit target
        /// </summary>
        private bool CheckHitTarget(Ray ray, out RaycastableObject hitTarget)
        {
            for (var i = 0; i < _targetColliders.Length; ++i) {
                if (!_targetColliders[i].Raycast(ray, out var hitInfo, 20))
                    continue;

                hitTarget = _targets[i];
                return true;
            }

            hitTarget = null;
            return false;
        }

        #region UI Event Callback

        private void OnDragBegin(PointerEventData eventData)
        {
            var ray = _camera.ScreenPointToRay(eventData.position);

            if (!CheckHitTarget(ray, out var hitTarget))
                return;

            _selectedObject = hitTarget;
            _selectedObject.Select();
            _selectedObject.Drag(eventData);
        }

        private void OnDragging(PointerEventData eventData)
        {
            if (!_selectedObject || !_selectedObject.raycastable)
                return;

            _selectedObject.Drag(eventData);
        }

        private void OnDragEnd(PointerEventData eventData)
        {
            if (!_selectedObject)
                return;

            _selectedObject.Drag(eventData);
            _selectedObject.UnSelect();
            _selectedObject = null;
        }

        #endregion
    }
}
