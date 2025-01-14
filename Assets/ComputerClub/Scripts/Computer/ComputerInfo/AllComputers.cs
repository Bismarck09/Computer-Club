using System;
using System.Collections.Generic;
using UnityEngine;

public class AllComputers : MonoBehaviour
{
    private List<Computer> _computers;

    public int Computers => _computers.Count;

    public static AllComputers Instance;

    public event Action OnComputerLoaded;

    private void Awake()
    {
        Instance = this;

        _computers = new();
    }

    public void AddComputer(Computer computer)
    {
        _computers.Add(computer);
    }

    public void Init(ComputerData computerData)
    {
        for (int i = 0; i < computerData._numberOfComputers; i++)
        {
            OnComputerLoaded?.Invoke();
        }
    }
}
