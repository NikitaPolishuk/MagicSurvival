using System.Numerics;
using UnityEngine;

namespace Asset.Scripts.Interface.IModel
{
    public interface IPhisycsMovable
    {
        float Speed { get; }
        Rigidbody Rigidbody { get; }
    }
}
