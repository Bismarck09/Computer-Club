using UnityEngine;

public class DataSaveLoader : MonoBehaviour
{
    [SerializeField] private GameBeginning _gameBeginning;

    private readonly IDataSaveLoader[] _dataSaveLoaders = {
        new CoinsSaveLoader(),
        new RatingSaveLoader(),
        new InteriorSaveLoader(),
        new ComputersSaveLoader(),
        new PriceOfObjectSaveLoader(),
        new PriceOfComputerSaveLoader(),
        new MainPlayerSaveLoader()
    };

    private void OnEnable()
    {
        _gameBeginning.OnGameStarted += LoadData;
    }

    private void OnDisable()
    {
        _gameBeginning.OnGameStarted -= LoadData;
    }

    private void SaveData()
    {
        foreach (var dataSaveLoader in _dataSaveLoaders)
        {
            dataSaveLoader.SaveData();
        }

        Repository.SaveState();
        PlayerPrefs.SetInt("firstOpen", 1);
        PlayerPrefs.DeleteAll();
    }

    private void LoadData()
    {
        Repository.LoadState();

        foreach (var dataSaveLoader in _dataSaveLoaders)
        {
            dataSaveLoader.LoadData();
        }
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }
}
