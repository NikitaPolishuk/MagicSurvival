using Asset.Scripts.Controller;
using Asset.Scripts.Interface.IModel;
using Unity.Cinemachine;
using UnityEngine;
using Zenject;

namespace Asset.Scripts.Installer
{
    public class GameplaySceneInstaller : MonoInstaller
    {
        [Header("Player")]
        [SerializeField] private Player _playerPrefab;
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private Transform _playerSpawnPoint;
        [Header("SceneSetup")]
        [SerializeField] private GamaCameraController _gamaCameraController;
        [SerializeField] private TachPadController _tachPad;

        public override void InstallBindings()
        {
            BindPlayer();
        }

        private void BindPlayer()
        {
            Container.Bind<PlayerConfig>().FromInstance(_playerConfig);
            Player player = Container.InstantiatePrefabForComponent<Player>(_playerPrefab, _playerSpawnPoint);
            Container.BindInterfacesAndSelfTo<Player>().FromInstance(player).AsSingle();
            Container.Bind<PlayerMovementHandler>().AsSingle().WithArguments(player).NonLazy();
            Container.BindInterfacesAndSelfTo<TachPadController>().FromInstance(_tachPad).AsSingle();
            Container.Bind<GamaCameraController>().FromInstance(_gamaCameraController).AsSingle().WithArguments(player);
        }
    }
    
}

