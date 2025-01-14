using UnityEngine;
using System.Collections.Generic;

public class SearchFreeComputer : MonoBehaviour
{
    private List<FreeComputers> _computers;

    private void Awake()
    {
        _computers = new List<FreeComputers>();
    }

    public FreeComputers Find()
    {
        foreach (var computer in _computers)
        {
            if (computer.IsFree)
            {
                computer.ChangeState(false);
                return computer;
            }
        }

        return null;
    }

    public void AddFreeComputer(Computer computer)
    {
        _computers.Add(computer.GetComponent<FreeComputers>());
    }
}
