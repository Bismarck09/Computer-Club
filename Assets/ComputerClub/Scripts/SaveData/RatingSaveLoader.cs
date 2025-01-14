using System;
using UnityEngine;

public class RatingSaveLoader : IDataSaveLoader
{
    public void SaveData()
    {
        float rating = Rating.Instance.CurrentRating;
        var data = new RatingData { Rating = rating };
        Repository.SetData(data);
    }

    public void LoadData()
    {
        RatingData data = Repository.GetData<RatingData>();
        Rating.Instance.ChangeRating(data.Rating);
    }
}

[Serializable]
public struct RatingData
{
    public float Rating;
}
