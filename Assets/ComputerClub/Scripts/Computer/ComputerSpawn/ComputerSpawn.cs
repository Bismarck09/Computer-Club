using System;
using System.Collections.Generic;
using UnityEngine;

public class ComputerSpawn : MonoBehaviour
{
    [SerializeField] private List<Computer> _computers;
    [SerializeField] private DecreaseCostOfComputer _decreaseCostOfComputer;
    [SerializeField] private AllComputers _allComputers;
    [SerializeField] private SearchFreeComputer _searchFreeComputer;

    private int _currentNumberComputer = 0;

    private void OnEnable()
    {
        _decreaseCostOfComputer.BoughtComputer += EnableComputer;
        _allComputers.OnComputerLoaded += EnableComputer;
    }

    private void OnDisable()
    {
        _decreaseCostOfComputer.BoughtComputer -= EnableComputer;
        _allComputers.OnComputerLoaded -= EnableComputer;
    }

    private void EnableComputer()
    {
        if (_computers.Count > _currentNumberComputer)
        {
            _computers[_currentNumberComputer].gameObject.SetActive(true);
            AddComputers();

            _currentNumberComputer++;
        } 
    }

    private void AddComputers()
    {
        _allComputers.AddComputer(_computers[_currentNumberComputer]);
        _searchFreeComputer.AddFreeComputer(_computers[_currentNumberComputer]);
    }
}
