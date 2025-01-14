using System;
using System.Collections;
using UnityEngine;

public class DecreaseCostOfComputer : MonoBehaviour
{
    private ComputerPayment _computerPayment;
    private ComputerPaymentText _computerPriceText;

    private Coroutine _decreasePriceCoroutine;
    private float _computerPrice;
    private float _currentPaymentAmount;
    private float _decreaseMultiplier;
    private bool _isOverpaymend;
    private bool _isStarted;

    public event Action<float> DecreasedPrice;
    public event Action BoughtComputer;

    public void StartDecreasePrice(float coins, ComputerPayment computerPayment, ComputerPaymentText computerPaymentText)
    {
        SetComputerPayment(computerPayment, computerPaymentText);

        _computerPrice = _computerPayment.ComputerPrice;
        _currentPaymentAmount = 0;
        _isOverpaymend = false;

        if (coins > 0 && _isStarted == false)
        {
            _decreasePriceCoroutine = StartCoroutine(DecreasePrice(coins));
            _isStarted = true;
        }
    }

    public void StopDecreasePrice()
    {
        if (_decreasePriceCoroutine != null)
            StopCoroutine(_decreasePriceCoroutine);

        DecreasedPrice?.Invoke(_currentPaymentAmount);
        _currentPaymentAmount = 0;
        _isStarted = false;
    }

    private void CheckOverpayment()
    {
        if (_currentPaymentAmount >= _computerPrice)
        {
            _currentPaymentAmount = _computerPrice;
            _isOverpaymend = true;

            CheckComputerBuy();
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

            _computerPriceText.ChangeComputerPriceText(_computerPrice - _currentPaymentAmount);

            yield return new WaitForSeconds(0.1f / _decreaseMultiplier);
            _decreaseMultiplier += _decreaseMultiplier;

            CheckOverpayment();
        }

        if (!(_currentPaymentAmount == _computerPrice))
            EquateCurrentPaymentAmount(coins);
    }

    private void EquateCurrentPaymentAmount(float coins)
    {
        _currentPaymentAmount = coins;
        DecreasedPrice?.Invoke(_currentPaymentAmount);

        _computerPriceText.ChangeComputerPriceText(_computerPrice - coins);
        _currentPaymentAmount = 0;

        _isStarted = false;
    }

    private void CheckComputerBuy()
    {
        if (_currentPaymentAmount == _computerPrice)
        {
            BoughtComputer?.Invoke();
            _computerPriceText.ChangeComputerPriceText(_computerPayment.FullComputerPrice);
        }
    }

    private void SetComputerPayment(ComputerPayment computerPayment, ComputerPaymentText computerPaymentText)
    {
        _computerPayment = computerPayment;
        _computerPriceText = computerPaymentText;
    }
}
