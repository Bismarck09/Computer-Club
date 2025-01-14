using System;

public class PriceOfObjectSaveLoader : IDataSaveLoader
{
    public void SaveData()
    {
        PriceOfObject[] priceOfObjects = PricesOfObjects.Instance.GetPricesOfObjects();
        int count = priceOfObjects.Length;

        PriceOfObjectData[] dataSet = new PriceOfObjectData[count];
        for (int i = 0; i < count; i++)
        {
            PriceOfObject priceOfObject = priceOfObjects[i];
            dataSet[i] = new PriceOfObjectData
            {
                Id = priceOfObject.Id,
                Price = priceOfObject.Price
            };
        }

        Repository.SetData(dataSet);
    }

    public void LoadData()
    {
        PriceOfObjectData[] dataSet = Repository.GetData<PriceOfObjectData[]>();
        int count = dataSet.Length;

        for (int i = 0; i < count; i++)
        {
            PricesOfObjects.Instance.Init(dataSet[i]);
        }
    }
}

[Serializable]
public struct PriceOfObjectData
{
    public float Price;
    public int Id;
}
