using UnityEngine;

public class PriceOfObject : MonoBehaviour
{
    [SerializeField] private PaymentForNeonlightText _paymentText;
    [SerializeField] private float _price;
    [SerializeField] private int _id;

    public int Id => _id;
    public float Price => _price;

    public void RemovePrice(float price)
    {
        if (price > _price)
            _price = 0;
        else
            _price -= price;
    }

    public void Init(PriceOfObjectData data)
    {
        _price = data.Price;
        _paymentText.ChangePriceText(_price);
    }
}
