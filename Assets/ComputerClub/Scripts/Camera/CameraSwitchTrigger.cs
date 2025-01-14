using Cinemachine;
using UnityEngine;

public class CameraSwitchTrigger : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _camera;
    [SerializeField] private CameraSwitcher _cameraSwitcher;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
            _cameraSwitcher.ChangeCamera(_camera);
    }
}
