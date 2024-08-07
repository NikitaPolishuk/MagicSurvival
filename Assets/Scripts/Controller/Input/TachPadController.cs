using Asset.Scripts.Interface.IController;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Asset.Scripts.Controller
{
    public class TachPadController : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler, ITouch
    {
        [SerializeField]
        private GameObject _tackhPad;
        [SerializeField]
        private float _sensitive;

        private Vector2 _previousTouchPosition;
        private Vector2 _delta;
        private bool _isDrag;
        public event Action<Vector2> Touch;

        private void FixedUpdate()
        {
            if (_isDrag)
            {
                Touch?.Invoke(_delta);
                Debug.Log("Touch Delta: " + _delta);
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (eventData.pointerCurrentRaycast.gameObject == _tackhPad)
            {
                Vector2 deltaPosition = eventData.position - _previousTouchPosition;
                _delta = deltaPosition * _sensitive / 1000;

                _isDrag = true;
            }
            else if (_isDrag)
            {
                _isDrag = false;
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (eventData.pointerCurrentRaycast.gameObject == _tackhPad)
            {
                _previousTouchPosition = eventData.position;
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _isDrag = false;
        }
    }
}
