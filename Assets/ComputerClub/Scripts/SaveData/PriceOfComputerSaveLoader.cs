using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriceOfComputerSaveLoader : IDataSaveLoader
{
    public void SaveData()
    {
        float price = ComputerPayment.Instance.ComputerPrice;
        var data = new PriceOfComputerData { Price = price };
        Repository.SetData(data);
    }

    public void LoadData()
    {
        PriceOfComputerData data = Repository.GetData<PriceOfComputerData>();
        ComputerPayment.Instance.Init(data.Price);
    }
}

[Serializable]
public struct PriceOfComputerData
{
    public float Price;
}
