using UnityEngine;

public class NewVisitors : MonoBehaviour
{
    private DistributionVisitors _distributionsVisitors;

    private void Awake()
    {
        _distributionsVisitors = GetComponent<DistributionVisitors>();
    }

    private void Distribute(VisitorChoise visitor)
    {
        _distributionsVisitors.Distribute(visitor);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out VisitorChoise visitor))
            Distribute(visitor);
    }
}
