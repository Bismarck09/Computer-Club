using System;
using UnityEngine;

public class NextToComputer : MonoBehaviour
{
    private Vector3 _visitorTarget;
    private ComeToComputer _computer;

    private bool _isMoveToComputer;

    public bool IsMoveToComputer => _isMoveToComputer;

    public event Action CameToComputer;

    public void SetVisitorTarget(Vector3 target, FreeComputers computer)
    {
        _visitorTarget = target;
        _computer = computer.GetComponent<ComeToComputer>();
        _isMoveToComputer = true;
    }

    private void Update()
    {
        if (_isMoveToComputer)
        {
            if (ShortenPosition(transform.position) == ShortenPosition(_visitorTarget))
            {
                CameToComputer?.Invoke();
                _computer.SitDownAtComputer(gameObject.GetComponent<VisitorModeSwitch>());
                _isMoveToComputer = false;
            }
        }
    }

    private Vector3 ShortenPosition(Vector3 position)
    {
        Vector3 shortenedPosition = new Vector3(Mathf.Round(position.x), Mathf.Round(position.y), Mathf.Round(position.z));
        return shortenedPosition;
    }
}
