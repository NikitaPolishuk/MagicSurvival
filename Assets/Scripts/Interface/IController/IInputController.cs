using System;
using UnityEngine;

namespace Asset.Scripts.Interface.IController
{
    public interface ITouch
    {
        public event Action<Vector2> Touch;
    }
}
