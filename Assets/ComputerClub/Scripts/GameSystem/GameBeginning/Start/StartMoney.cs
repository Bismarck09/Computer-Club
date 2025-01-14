using UnityEngine;

public class StartMoney : MonoBehaviour
{
    [SerializeField] private GameBeginning _gameBeginning;
    [SerializeField] private CoinsStorage _coinsData;

    private float _startCoins = 500000;

    private void OnEnable()
    {
        _gameBeginning.OnGameFirstOpen += GiveStartCoins;
    }

    private void OnDisable()
    {
        _gameBeginning.OnGameFirstOpen -= GiveStartCoins;
    }

    private void GiveStartCoins()
    {
        _coinsData.AddCoin(_startCoins);
    }
}
