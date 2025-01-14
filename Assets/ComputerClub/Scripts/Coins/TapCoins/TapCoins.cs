using UnityEngine;

public class TapCoins : MonoBehaviour
{
    [SerializeField] private CoinsStorage _coinsData;
    [SerializeField] private Rating _rating;

    private float _numberOfCoinsForTap = 100;

    public void Tap()
    {
        _coinsData.AddCoin(_numberOfCoinsForTap * _rating.CurrentRating);
    }
}
