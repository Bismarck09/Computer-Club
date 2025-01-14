using UnityEngine;

public class LeavingClub : MonoBehaviour
{
    [SerializeField] private Vector3 _targetExit;

    private VisitorMovement _movement;
    private DecreaceOfPurchaseTime _decreaceOfPurchaseTime;

    private void Awake()
    {
        _movement = GetComponent<VisitorMovement>();
        _decreaceOfPurchaseTime = GetComponent<DecreaceOfPurchaseTime>();
    }

    private void OnEnable()
    {
        _decreaceOfPurchaseTime.TimeIsOver += Leave;
    }

    private void OnDisable()
    {
        _decreaceOfPurchaseTime.TimeIsOver -= Leave;
    }

    public void Leave()
    {
        _movement.Move(_targetExit);
    }
}
