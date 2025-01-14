using UnityEngine;

public class ComputerStatus : MonoBehaviour
{
    private DecreaceOfPurchaseTime _decreaseOfPurchaceTime;

    private FreeComputers _freeComputers;

    private void Awake()
    {
        _decreaseOfPurchaceTime = GetComponent<DecreaceOfPurchaseTime>();
    }

    private void OnEnable()
    {
        _decreaseOfPurchaceTime.TimeIsOver += ReleaseComputer;
    }

    private void OnDisable()
    {
        _decreaseOfPurchaceTime.TimeIsOver -= ReleaseComputer;
    }

    private void ReleaseComputer()
    {
        if (_freeComputers != null)
            _freeComputers.ChangeState(true);
    }

    public void SetFreeComputer(FreeComputers freeComputers)
    {
        _freeComputers = freeComputers;
    }
}
