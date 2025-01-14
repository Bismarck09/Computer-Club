using UnityEngine;

public class StartVisitorMovement : MonoBehaviour
{
    [SerializeField] private Vector3 _target;

    private VisitorMovement _visitorMovement;

    private void Awake()
    {
        _visitorMovement = GetComponent<VisitorMovement>();
        StartMove();
    }

    private void StartMove()
    {
        _visitorMovement.Move(_target);
    }
}
