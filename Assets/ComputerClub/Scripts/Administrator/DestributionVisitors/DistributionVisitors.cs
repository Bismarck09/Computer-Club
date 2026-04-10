using UnityEngine;
using System.Collections;

public class DistributionVisitors : MonoBehaviour
{
    [SerializeField] private PlayTimePayment _playTimePayment;
    [SerializeField] private float _delayTime;

    private SearchFreeComputer _searchFreeComputer;
    private VisitorMovement _visitorMovement;
    private FreeComputers _computer;
    private AdminQueue _adminQueue;
    private bool _isDistributing;

    private void Awake()
    {
        _searchFreeComputer = GetComponent<SearchFreeComputer>();
        _adminQueue = GetComponent<AdminQueue>();
    }

    void Update()
    {
        if (!_isDistributing)
        {
            _isDistributing = true;
            Visitor visitor = _adminQueue.GetNextVisitor();

            if (visitor != null)
                Distribute(visitor.GetComponent<VisitorChoise>());
            else
                _isDistributing = false;
        }
    }

    private bool SearchComputer()
    {
        _computer = _searchFreeComputer.Find();
        return _computer != null;
    }

    private void Distribute(VisitorChoise visitor)
    {
        if (SearchComputer())
        {
            _visitorMovement = visitor.GetComponent<VisitorMovement>();
            StartCoroutine(DistributeCoroutine(visitor));
        }
        else
        {
            _isDistributing = false;
        }
    }

    private IEnumerator DistributeCoroutine(VisitorChoise visitor)
    {
        yield return new WaitForSeconds(_delayTime);

        _visitorMovement.Move(_computer.GetTargetToMove());
        AssignComputerForVisitor(visitor, _computer);

        _playTimePayment.Pay(_computer.GetComponent<Computer>().PriceForHour);
        _adminQueue.RemoveVisitor(visitor.GetComponent<Visitor>());
        _computer = null;
        _isDistributing = false;
    }

    private void AssignComputerForVisitor(VisitorChoise visitor, FreeComputers computer)
    {
        ComputerStatus computerStatus = visitor.GetComponent<ComputerStatus>();
        NextToComputer nextToComputer = visitor.GetComponent<NextToComputer>();

        nextToComputer.SetVisitorTarget(computer.GetTargetToMove(), computer);
        computerStatus.SetFreeComputer(computer);
    }
}
