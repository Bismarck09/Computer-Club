using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;

    private void OnValidate()
    {
        if (_target != null)
            return;
    }

    private void LateUpdate()
    {
        transform.position = _target.position + _offset;
    }
}
