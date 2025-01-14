using UnityEngine;

public class ExitOnMap : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Visitor visitor))
            Destroy(visitor.gameObject);
    }
}
