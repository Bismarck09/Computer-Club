using UnityEngine;
using UnityEngine.AI;

public class VisitorMovement : MonoBehaviour
{
    private NavMeshAgent _agent;

    public bool IsMoving { get; private set; }

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (_agent.velocity == Vector3.zero)
            IsMoving = false;
        else
            IsMoving = true;
    }

    public void Move(Vector3 target)
    {
        _agent.SetDestination(target);
    }
}
