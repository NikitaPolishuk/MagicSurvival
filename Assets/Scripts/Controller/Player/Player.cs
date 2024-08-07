using Asset.Scripts.Interface.IModel;
using UnityEngine;
using Zenject;

namespace Asset.Scripts.Controller
{
    public class Player : Creature, IPhisycsMovable
    {
        [SerializeField] private Rigidbody _rigidbody;

        public float Speed { get; private set; }
        public Rigidbody Rigidbody => _rigidbody;

        [Inject]
        private void Init(PlayerConfig playerConfig)
        {
            Speed = playerConfig.Speed;
        }
    }
}
