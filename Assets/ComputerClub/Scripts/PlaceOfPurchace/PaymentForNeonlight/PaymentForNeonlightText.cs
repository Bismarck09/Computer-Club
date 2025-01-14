using TMPro;
using UnityEngine;

public class PaymentForNeonlightText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _paymentText;

    public void ChangePriceText(float price)
    {
        _paymentText.text = price.ToString();
    }
}
