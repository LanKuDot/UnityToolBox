using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace LanKuDot.UnityToolBox.UI
{
    /// <summary>
    /// The button for detecting the holding action
    /// </summary>
    [RequireComponent(typeof(Button))]
    public class HoldButton : MonoBehaviour,
        IPointerDownHandler, IPointerMoveHandler, IPointerExitHandler
    {
        [SerializeField]
        [Tooltip("The original button")]
        private Button _button;
        [SerializeField]
        [Tooltip("The time interval for treating the click action as holding")]
        private float _holdTime = 1f;
        [SerializeField]
        [Tooltip("The callback to be invoked when a clicking action is happened")]
        private UnityEvent _onClick;
        [SerializeField]
        [Tooltip("The callback to be invoked when a holding action is happened")]
        private UnityEvent _onHold;
        [SerializeField]
        [Tooltip("Whether to continuously firing the onHold event or not")]
        private bool _autoFiring;
        [SerializeField]
        [Tooltip("The interval of continuously firing")]
        private float _autoFiringInterval = 0.15f;

        /// <summary>
        /// Is the hold button interactable?
        /// </summary>
        public bool interactable
        {
            get => _button.interactable;
            set {
                _button.interactable = value;
                if (!value)
                    KillHoldingCoroutine();
            }
        }
        /// <summary>
        /// The event to be invoked when the short click is detected
        /// </summary>
        public UnityEvent onClick => _onClick;
        /// <summary>
        /// The event to be invoked when the hold is detected
        /// </summary>
        public UnityEvent onHold => _onHold;

        /// <summary>
        /// Is the holding checking routine on?
        /// </summary>
        private bool _isInHoldingChecking;
        /// <summary>
        /// Is the onHold event fired in this touching?
        /// </summary>
        private bool _isOnHoldFired;
        /// <summary>
        /// The coroutine for checking the holding action
        /// </summary>
        private Coroutine _holdingCoroutine;
        /// <summary>
        /// The tolerance for detecting the stability of the finger
        /// </summary>
        private const float _holdDistanceTolerance = 20f;
        /// <summary>
        /// The position of the finger at the beginning of the touch
        /// </summary>
        private Vector2 _startPos;

        private void Reset()
        {
            _button = GetComponent<Button>();
        }

        private void Awake()
        {
            _button.onClick.AddListener(OnOriginalClick);
        }

        private void KillHoldingCoroutine()
        {
            if (!_isInHoldingChecking)
                return;

            StopCoroutine(_holdingCoroutine);
            _isInHoldingChecking = false;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (!interactable)
                return;

            _isOnHoldFired = false;
            _isInHoldingChecking = true;
            _startPos = eventData.position;
            _holdingCoroutine = StartCoroutine(HoldingCoroutine());
        }

        public void OnPointerMove(PointerEventData eventData)
        {
            if (!_isInHoldingChecking
                || Vector2.Distance(_startPos, eventData.position)
                    < _holdDistanceTolerance)
                return;

            KillHoldingCoroutine();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            KillHoldingCoroutine();
        }

        private void OnOriginalClick()
        {
            if (!_isOnHoldFired)
                _onClick.Invoke();

            KillHoldingCoroutine();
        }

        private IEnumerator HoldingCoroutine()
        {
            yield return new WaitForSeconds(_holdTime);
            _onHold.Invoke();
            _isOnHoldFired = true;

            if (!_autoFiring)
                yield break;

            while (true) {
                yield return new WaitForSeconds(_autoFiringInterval);
                _onHold.Invoke();
            }
        }
    }
}
