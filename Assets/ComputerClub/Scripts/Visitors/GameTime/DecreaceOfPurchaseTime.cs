using System;
using UnityEngine;

public class DecreaceOfPurchaseTime : MonoBehaviour
{
    private NextToComputer _nextToComputer;

    private float _playTime;
    private float _elapsedTime;
    private bool _isStartDecrease;

    public event Action TimeIsOver;

    private void Awake()
    {
        _nextToComputer = GetComponent<NextToComputer>();

        _playTime = 10;
    }

    private void OnEnable()
    {
        _nextToComputer.CameToComputer += StartDecreasePurchaseTime;
    }

    private void OnDisable()
    {
        _nextToComputer.CameToComputer -= StartDecreasePurchaseTime;
    }

    private void Update()
    {
        if (_isStartDecrease)
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime >= _playTime)
            {
                TimeIsOver?.Invoke();
                _isStartDecrease = false;
            }
        }
    }

    private void StartDecreasePurchaseTime()
    {
        _isStartDecrease = true;
    }
}
