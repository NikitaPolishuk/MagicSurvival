using Asset.Scripts.Interface.IController;
using System;
using UnityEngine;
using Zenject;

namespace Asset.Scripts.Controller
{
    public class MobileInput : ITouch, ITickable
    {
        public event Action<Vector2> Touch;

        public void Tick()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                var delta = touch.deltaPosition;
                Touch.Invoke(delta);
                Debug.Log("Touch Delta: " + delta);
            }
        }
    }
}
