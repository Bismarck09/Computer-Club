using UnityEngine;

public class StartVisitorMovement : MonoBehaviour
{
    private AdminQueue _adminQueue;
    private VisitorMovement _visitorMovement;

    public void Init(AdminQueue adminQueue)
    {
        _adminQueue = adminQueue;
        _visitorMovement = GetComponent<VisitorMovement>();

        StartMove();
    }

    private void StartMove()
    {
        if (_adminQueue.HasFreeSlot())
            _adminQueue.AddToQueue(GetComponent<Visitor>());
        else
            _visitorMovement.GetComponent<LeavingClub>().Leave();
    }
}
