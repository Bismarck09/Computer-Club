using Cinemachine;
using UnityEngine;

public class OpenClubNotification : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _cameraNeonNotification;
    [SerializeField] private CameraSwitcher _cameraSwitcher;
    [SerializeField] private GameObject _buttonTapCoins;
    [SerializeField] private GameObject _openClubNotification;
    [SerializeField] private SpawnVisitors _spawnVisitors;

    private void Update()
    {
        if (Input.GetMouseButton(0))
            OpenClub();
    }

    public void OpenClub()
    {
        _cameraSwitcher.ChangeCamera(_cameraNeonNotification);
        _buttonTapCoins.SetActive(true);
        _spawnVisitors.StartSpawn();

        PlayerPrefs.SetInt("startSpawn", 1);

        gameObject.SetActive(false);
        _openClubNotification.SetActive(false);
    }
}
