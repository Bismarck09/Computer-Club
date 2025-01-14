using TMPro;
using UnityEngine;

public class ComputerPaymentText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _computerPriceText;

    private ComputerPayment _computerPayment;

    private void Start()
    {
        _computerPayment = GetComponent<ComputerPayment>();
        _computerPriceText.text = _computerPayment.ComputerPrice.ToString();
    }

    public void ChangeComputerPriceText(float computerPrice)
    {
        _computerPriceText.text = computerPrice.ToString();
    }
}
