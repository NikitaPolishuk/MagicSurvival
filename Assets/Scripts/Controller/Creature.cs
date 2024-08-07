using Asset.Scripts.Interface;
using Asset.Scripts.Interface.IController;
using Asset.Scripts.Interface.IModel;
using System;
using UnityEngine;

namespace Asset.Scripts.Controller
{
    public abstract class Creature : MonoBehaviour, IAttackeble, ITransform, IHealth
    {
        public string Name { get; private set; }
        public float Health { get; private set; }
        public bool IsAlive => Health > 0;
        public Transform Transform => gameObject.transform;

        public void Attack(IHealth attacker)
        {
            attacker.TakeDamage(1);
        }

        public void Die()
        {
            throw new NotImplementedException();
        }

        public void TakeDamage(float amount)
        {
            if (amount < 0) throw new ArgumentOutOfRangeException(nameof(amount), "Damage amount cannot be negative.");
            Health = Mathf.Max(Health - amount, 0);
            if (!IsAlive)
            {
                Die();
            }
        }

    }
}
