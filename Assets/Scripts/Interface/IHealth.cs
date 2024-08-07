namespace Asset.Scripts.Interface
{
    public interface IHealth
    {
        float Health { get; }
        void TakeDamage(float amount);
        bool IsAlive { get; }
        void Die();
    }
}