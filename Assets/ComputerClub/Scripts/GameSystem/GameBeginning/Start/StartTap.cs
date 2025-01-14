using UnityEngine;

public class StartTap : MonoBehaviour
{
    [SerializeField] private GameBeginning _gameBeginning;
    [SerializeField] private GameObject _addCoinForTap;

    private void OnEnable()
    {
        _gameBeginning.OnGameFirstOpen += EnableTap;
        _gameBeginning.OnGameStarted += EnableTap;
    }

    private void OnDisable()
    {
        _gameBeginning.OnGameFirstOpen -= EnableTap;
        _gameBeginning.OnGameStarted -= EnableTap;
    }

    private void EnableTap()
    {
        _addCoinForTap.SetActive(true);
    }
}
