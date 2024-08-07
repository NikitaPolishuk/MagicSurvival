using Asset.Scripts.Interface.IModel;
using Unity.Cinemachine;
using UnityEngine;
using Zenject;

namespace Asset.Scripts.Controller
{
    public class GamaCameraController : MonoBehaviour
    {
        [SerializeField] private CinemachineCamera _playerTrackingCamera;

        [Inject]
        private void Init(ITransform transform)
        {
            _playerTrackingCamera.Target.TrackingTarget = transform.Transform;
        }

    }
}
