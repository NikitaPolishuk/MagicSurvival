using Zenject;

namespace Asset.Scripts.Controller
{
    public class EnemySpawner : ITickable
    {
        private BaseEnemy.Factory _enemyFactory;

        public EnemySpawner(BaseEnemy.Factory enemyFactory)
        {
            _enemyFactory = enemyFactory;
        }

        public void Tick()
        {
            var enemy = _enemyFactory.Create();
        }
    }
}
