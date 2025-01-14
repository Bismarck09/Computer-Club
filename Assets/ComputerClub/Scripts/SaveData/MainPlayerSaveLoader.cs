using System;
using UnityEngine;

public class MainPlayerSaveLoader : IDataSaveLoader
{
    public void SaveData()
    {
        int playerNumber = Person.Instance.PersonNumber;
        var data = new MainPlayer { PlayerNumber = playerNumber };
        Repository.SetData(data);
    }

    public void LoadData()
    {
        MainPlayer data = Repository.GetData<MainPlayer>();
        Person.Instance.LoadMainPerson(data.PlayerNumber);
    }
}

[Serializable]
public struct MainPlayer
{
    public int PlayerNumber;
}
