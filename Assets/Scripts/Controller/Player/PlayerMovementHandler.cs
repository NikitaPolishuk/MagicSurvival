using Asset.Scripts.Interface.IController;
using Asset.Scripts.Interface.IModel;
using System;
using UnityEngine;
using Zenject;


namespace Asset.Scripts.Controller
{
    public class PlayerMovementHandler: IDisposable
    {
        private ITouch _input;
        private IPhisycsMovable _phisycsMovable;

        public PlayerMovementHandler(ITouch input, IPhisycsMovable phisycsMovable)
        {
            Debug.Log("PhisycsMovement");
            _input = input;
            _phisycsMovable = phisycsMovable;

            _input.Touch += MoveHandler;
        }

        private void MoveHandler(Vector2 vector2) => Move(_phisycsMovable, vector2);

        public void Move(IPhisycsMovable movable, Vector2 deltaTouch)
        {
            var rigidbody = movable.Rigidbody;
            var directered = new Vector3(deltaTouch.x, 0, deltaTouch.y) * movable.Speed;
            rigidbody.MovePosition(rigidbody.position + directered);
        }

        public void Dispose()
        {
            _input.Touch -= MoveHandler;
        }
    }
}
