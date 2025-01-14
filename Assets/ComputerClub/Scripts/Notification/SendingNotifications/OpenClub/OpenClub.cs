using DG.Tweening;
using UnityEngine;

public class OpenClub : MonoBehaviour
{
    [SerializeField] private GameObject[] _notificationElements;
    [SerializeField] private AllComputers _allComputers;

    private bool _isOpeningNotification;

    private void Update()
    {
        if (_allComputers.Computers == 5 && _isOpeningNotification == false)
            OpenNotificationAboutOpeningClub();
    }

    private void OpenNotificationAboutOpeningClub()
    {
        for (int i = 0; i < _notificationElements.Length; i++)
        {
            _notificationElements[i].SetActive(true);
            _notificationElements[i].transform.DOScale(1, 0.3f).From(0);
        }

        _isOpeningNotification = true;
    }
}
