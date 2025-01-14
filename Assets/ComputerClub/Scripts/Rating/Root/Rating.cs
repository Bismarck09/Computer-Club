using UnityEngine;

public class Rating : MonoBehaviour
{
    private UIRating _ratingUI;

    private float _rating;

    public float CurrentRating => _rating;

    public static Rating Instance;

    private void Awake()
    {
        Instance = this;

        _ratingUI = GetComponent<UIRating>();

        if (!PlayerPrefs.HasKey("firstOpen"))
            _rating = 1;
    }

    public void ChangeRating(float currentOfNewRating)
    {
        _rating += currentOfNewRating;
        _ratingUI.ChangeRating(_rating);
    }
}
