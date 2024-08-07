using Asset.Scripts.Interface.IController;
using System;
using UnityEngine;
using Zenject;

namespace Asset.Scripts.Controller
{
    public class MouseInput : ITouch, ITickable
    {
        public event Action<Vector2> Touch;
        private Vector2 _lastMousePosition;
        private Vector2 _currentMousePosition;
        private Vector2 _lastDelta;

        public void Tick()
        {
            if (Input.GetMouseButtonDown(0)) _lastMousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            if (Input.GetMouseButton(0))
            {
                Vector2 delta;
                _currentMousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                if (_currentMousePosition != _lastMousePosition)
                {
                    delta = _currentMousePosition - _lastMousePosition;
                    _lastMousePosition = _currentMousePosition;
                }
                else
                {
                    delta = _lastDelta;
                }

                if(delta != Vector2.zero)
                {
                    Touch.Invoke(delta);
                    _lastDelta = delta;
                    Debug.Log("Touch Delta: " + delta);
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                _lastDelta = Vector2.zero;
            }
        }
    }
}

