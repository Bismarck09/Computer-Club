using System.Collections.Generic;
using UnityEngine;

public class PlaceOfPurchaceOffset : MonoBehaviour
{
    [SerializeField] private List<Vector3> _newPosition;
    [SerializeField] private DecreaseCostOfComputer _decreaseCostOfComputer;
    [SerializeField] private AllComputers _allComputers;

    private int _currentNumberPosition = 0;

    private void OnEnable()
    {
        _decreaseCostOfComputer.BoughtComputer += ChangePosition;
        _allComputers.OnComputerLoaded += ChangePosition;
    }

    private void OnDisable()
    {
        _decreaseCostOfComputer.BoughtComputer -= ChangePosition;
        _allComputers.OnComputerLoaded -= ChangePosition;
    }

    private void ChangePosition()
    {
        if (_newPosition.Count > _currentNumberPosition)
        {
            transform.position = _newPosition[_currentNumberPosition];
            _currentNumberPosition++;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
