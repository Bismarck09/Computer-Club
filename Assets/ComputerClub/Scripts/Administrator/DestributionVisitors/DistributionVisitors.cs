using UnityEngine;

public class DistributionVisitors : MonoBehaviour
{
    [SerializeField] private PlayTimePayment _playTimePayment;

    private SearchFreeComputer _searchFreeComputer;
    private VisitorMovement _visitorMovement;

    private void Awake()
    {
        _searchFreeComputer = GetComponent<SearchFreeComputer>();
    }

    public void Distribute(VisitorChoise visitor)
    {
        FreeComputers computer = _searchFreeComputer.Find();

        _visitorMovement = visitor.GetComponent<VisitorMovement>();

        if (computer != null)
        {
            _visitorMovement.Move(computer.GetTargetToMove());
            AssignComputerForVisitor(visitor, computer);

            _playTimePayment.Pay(computer.GetComponent<Computer>().PriceForHour);
        }
        else
        {
            _visitorMovement.GetComponent<LeavingClub>().Leave();
        }
    }

    private void AssignComputerForVisitor(VisitorChoise visitor, FreeComputers computer)
    {
        ComputerStatus computerStatus = visitor.GetComponent<ComputerStatus>();
        NextToComputer nextToComputer = visitor.GetComponent<NextToComputer>();

        nextToComputer.SetVisitorTarget(computer.GetTargetToMove(), computer);
        computerStatus.SetFreeComputer(computer);
    }
}
