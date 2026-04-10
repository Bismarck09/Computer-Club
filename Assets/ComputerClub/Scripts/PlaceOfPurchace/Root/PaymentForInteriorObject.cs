using System;
using System.Collections;
using UnityEngine;

public class PaymentForInteriorObject : MonoBehaviour
{
    [SerializeField] private InteriorObject _interiorObject;
    [SerializeField] private CoinsStorage _coins;
    [SerializeField] private PriceOfObject _priceOfObject;


    private PaymentForNeonlightText _paymentForNeonlightText;

    private Coroutine _decreasePriceCoroutine;
    private float _currentPaymentAmount;
    private float _decreaseMultiplier;
    private float _price;
    private bool _isOverpaymend;
    private bool _isStarted;

    public InteriorObject Interior => _interiorObject;

    private void Awake()
    {
        _paymentForNeonlightText = GetComponent<PaymentForNeonlightText>();
    }

    public void StartDecreasePrice()
    {
        _currentPaymentAmount = 0;
        _price = _priceOfObject.Price;
        _isOverpaymend = false;

        if (_coins.NumberOfCoins > 0 && _isStarted == false)
        {
            _decreasePriceCoroutine = StartCoroutine(DecreasePrice(_coins.NumberOfCoins));
            _isStarted = true;
        }
    }

    public void StopDecreasePrice()
    {
        if (_decreasePriceCoroutine != null)
            StopCoroutine(_decreasePriceCoroutine);

        DecreaseMoney();
        _isStarted = false;
    }

    private void CheckOverpayment()
    {
        if (_currentPaymentAmount >= _price)
        {
            _currentPaymentAmount = _price;
            _isOverpaymend = true;

            CheckNeonlightBuy();
        }
    }

    private IEnumerator DecreasePrice(float coins)
    {
        _decreaseMultiplier = 1;

        while (coins > _currentPaymentAmount)
        {
            if (_isOverpaymend)
                yield break;

            _currentPaymentAmount += Convert.ToInt32(_decreaseMultiplier);

            _paymentForNeonlightText.ChangePriceText(_price - _currentPaymentAmount);

            yield return new WaitForSeconds(0.1f / _decreaseMultiplier);
            _decreaseMultiplier += _decreaseMultiplier;

            CheckOverpayment();
        }

        if (!(_currentPaymentAmount == _price))
            EquateCurrentPaymentAmount(coins);
    }

    private void EquateCurrentPaymentAmount(float coins)
    {
        _currentPaymentAmount = coins;
        _paymentForNeonlightText.ChangePriceText(_price - coins);

        DecreaseMoney();
        _isStarted = false;
    }

    private void CheckNeonlightBuy()
    {
        if (_currentPaymentAmount == _price)
        {
            _coins.RemoveCoin(_currentPaymentAmount);

            _interiorObject.EnableInteriorObject();


            gameObject.SetActive(false);
        }
    }

    private void DecreaseMoney()
    {
        _coins.RemoveCoin(_currentPaymentAmount);
        _priceOfObject.RemovePrice(_currentPaymentAmount);
        _currentPaymentAmount = 0;
    }
}
