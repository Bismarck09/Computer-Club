using System;
using UnityEngine;

public class ComputerPayment : MonoBehaviour
{
    [SerializeField] private CoinsStorage _coins;
    [SerializeField] private DecreaseCostOfComputer _decreaseCostOfComputer;
    [SerializeField] private int _computerPrice;

    private ComputerPaymentArea _computerPaymentArea;

    private float _currentComputerPrice;

    public float ComputerPrice => _currentComputerPrice;
    public int FullComputerPrice => _computerPrice;

    public static ComputerPayment Instance;

    private void Awake()
    {
        Instance = this;

        _computerPaymentArea = GetComponent<ComputerPaymentArea>();

        if (!PlayerPrefs.HasKey("firstOpen"))
            _currentComputerPrice = _computerPrice;
    }

    private void OnEnable()
    {
        _computerPaymentArea.EnteredZone += StartWritingOffCoins;
        _computerPaymentArea.CameOutZone += StopWritingOffCoins;
        _decreaseCostOfComputer.DecreasedPrice += GiveCoinsForComputer;
    }

    private void OnDisable()
    {
        _computerPaymentArea.EnteredZone -= StartWritingOffCoins;
        _computerPaymentArea.CameOutZone -= StopWritingOffCoins;
        _decreaseCostOfComputer.DecreasedPrice -= GiveCoinsForComputer;
    }

    public void Init(float price)
    {
        _currentComputerPrice = price;
    }

    private void StartWritingOffCoins()
    {
        if (_coins.NumberOfCoins > 0)
            _decreaseCostOfComputer.StartDecreasePrice(_coins.NumberOfCoins, this, GetComponent<ComputerPaymentText>());
    }

    private void StopWritingOffCoins()
    {
        _decreaseCostOfComputer.StopDecreasePrice();
    }

    private void GiveCoinsForComputer(float coins)
    {
        _currentComputerPrice -= coins;
        CheckPriceComputer();
    }

    private void CheckPriceComputer()
    {
        if (_currentComputerPrice <= 0)
        {
            _currentComputerPrice = _computerPrice;
        }
    }
}
