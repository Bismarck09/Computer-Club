using UnityEngine;

public class PaymentForNeonlightArea : MonoBehaviour
{
    private PaymentForInteriorObject _paymentForNeonlight;

    private void Awake()
    {
        _paymentForNeonlight = GetComponent<PaymentForInteriorObject>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
            _paymentForNeonlight.StartDecreasePrice();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
            _paymentForNeonlight.StopDecreasePrice();
    }
}
