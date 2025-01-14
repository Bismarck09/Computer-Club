using System;

public class CoinsSaveLoader : IDataSaveLoader
{
    public void SaveData()
    {
        float coins = CoinsStorage.Instance.NumberOfCoins;
        var data = new CoinsData { Coins = coins };
        Repository.SetData(data);
    }

    public void LoadData()
    {
        CoinsData data = Repository.GetData<CoinsData>();
        CoinsStorage.Instance.AddCoin(data.Coins);
    }
}

[Serializable]
public struct CoinsData
{
    public float Coins;
}
