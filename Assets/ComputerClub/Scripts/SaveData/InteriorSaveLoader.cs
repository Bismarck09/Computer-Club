using System;
using UnityEngine;


public class InteriorSaveLoader : IDataSaveLoader
{
    public void SaveData()
    {
        InteriorObject[] interiorObjects = Interior.Instance.GetAllInterior();
        int count = interiorObjects.Length;

        InteriorData[] dataSet = new InteriorData[count];
        for (int i = 0; i < count; i++)
        {
            InteriorObject interiorObject = interiorObjects[i];
            dataSet[i] = new InteriorData
            {
                Id = interiorObject.ID,
                IsPurchased = interiorObject.IsPurchased
            };
        }

        Repository.SetData(dataSet);
    }

    public void LoadData()
    {
        InteriorData[] dataSet = Repository.GetData<InteriorData[]>(); 
        int count = dataSet.Length;

        for (int i = 0;i < count; i++)
        {
            Interior.Instance.Init(dataSet[i]);
        }
    }
}

[Serializable]
public struct InteriorData
{
    public int Id;
    public bool IsPurchased;
}
