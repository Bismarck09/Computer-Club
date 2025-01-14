using UnityEngine;
using YG;

public class FullScreenAdv : MonoBehaviour
{
    [SerializeField] private YandexGame _sdk;

    private float _gapBetweenAds = 100;
    private float _timeElapsed;
    private bool _isAdvWatching;

    public bool IsAdvWatching => _isAdvWatching;

    public void StartFullScreenAdv()
    {
        _isAdvWatching = true;
        _sdk._FullscreenShow();
    }

    public void StopFullScreenAdv()
    {
        _isAdvWatching = false;
    }

    private void Update()
    {
        _timeElapsed += Time.deltaTime;

        if (_gapBetweenAds <= _timeElapsed)
        {
            StartFullScreenAdv();
            _timeElapsed = 0;
        }
    }
}
