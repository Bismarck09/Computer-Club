using Cinemachine;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera[] _cameras;

    public void ChangeCamera(CinemachineVirtualCamera camera)
    {
        for (int i = 0; i < _cameras.Length; i++)
        {
            if (_cameras[i] == camera && camera.Priority != 1)
            {
                _cameras[i].Priority = 1;
            }
            else
            {
                _cameras[i].Priority = 0;
            }
        }
    }
}
