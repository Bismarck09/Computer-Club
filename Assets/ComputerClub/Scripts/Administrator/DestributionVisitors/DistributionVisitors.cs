using UnityEngine;
using System.Collections;

public class DistributionVisitors : MonoBehaviour
{
    [SerializeField] private PlayTimePayment _playTimePayment;
    [SerializeField] private float _delayTime;

    private SearchFreeComputer _searchFreeComputer;
    private VisitorMovement _visitorMovement;
    private FreeComputers _computer;

    private void Awake()
    {
        _searchFreeComputer = GetComponent<SearchFreeComputer>();
    }

    public void Distribute(VisitorChoise visitor)
    {
        _computer = _searchFreeComputer.Find();
        _visitorMovement = visitor.GetComponent<VisitorMovement>();

        if (_computer != null)
        {
            StartCoroutine(DistributeCoroutine(visitor));
            
        }

    }

    private IEnumerator DistributeCoroutine(VisitorChoise visitor)
    {
        yield return new WaitForSeconds(_delayTime);

        _visitorMovement.Move(_computer.GetTargetToMove());
        AssignComputerForVisitor(visitor, _computer);

        _playTimePayment.Pay(_computer.GetComponent<Computer>().PriceForHour);
    }

    private void AssignComputerForVisitor(VisitorChoise visitor, FreeComputers computer)
    {
        ComputerStatus computerStatus = visitor.GetComponent<ComputerStatus>();
        NextToComputer nextToComputer = visitor.GetComponent<NextToComputer>();

        nextToComputer.SetVisitorTarget(computer.GetTargetToMove(), computer);
        computerStatus.SetFreeComputer(computer);
    }
}
