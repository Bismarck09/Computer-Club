using System;
using UnityEngine;

public class ComputersSaveLoader : IDataSaveLoader
{
    public void LoadData()
    {
        ComputerData data = Repository.GetData<ComputerData>();
        AllComputers.Instance.Init(data);
    }

    public void SaveData()
    {
        int numberOfComputers = AllComputers.Instance.Computers;
        ComputerData data = new ComputerData { _numberOfComputers = numberOfComputers };
        Repository.SetData(data);
    }
}

[Serializable]
public struct ComputerData
{
    public int _numberOfComputers;
}
