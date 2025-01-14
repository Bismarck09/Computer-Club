using UnityEngine;

public class ComeToComputer : MonoBehaviour
{
    [SerializeField] private GameObject[] _sitVisitors;

    private VisitorModeSwitch _visitorModeSwitch;
    private DecreaceOfPurchaseTime _decreaceOfPurchaseTime;

    private void InitOfVisitor(VisitorModeSwitch visitorModeSwitch)
    {
        _visitorModeSwitch = visitorModeSwitch;
        _decreaceOfPurchaseTime = visitorModeSwitch.GetComponent<DecreaceOfPurchaseTime>();
    }

    public void SitDownAtComputer(VisitorModeSwitch visitorModeSwitch)
    {
        InitOfVisitor(visitorModeSwitch);
        _visitorModeSwitch.SwitchModeVisitor(false, _sitVisitors);

        _decreaceOfPurchaseTime.TimeIsOver += GetUpFromComputer;
    }

    public void GetUpFromComputer()
    {
        _visitorModeSwitch.SwitchModeVisitor(true, _sitVisitors);
        _decreaceOfPurchaseTime.TimeIsOver -= GetUpFromComputer;
    }
}
