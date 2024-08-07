using Zenject;

namespace Asset.Scripts.Controller
{
    public class BaseEnemy : Creature
    {
        [Inject]
        private void Init()
        {
         
        }

        public class Factory : PlaceholderFactory<BaseEnemy>
        {
        }
    }
}
