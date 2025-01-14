using UnityEngine;

public class GameStatus : MonoBehaviour
{
    [SerializeField] private AudioSource _backgroundMusic;
    [SerializeField] private FullScreenAdv _fullScreenAdv;

    private void StopGame()
    {
        _backgroundMusic.mute = true;
        Time.timeScale = 0;
    }

    private void ResumeGame()
    {
        _backgroundMusic.mute = false;
        Time.timeScale = 1;
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus && !_fullScreenAdv.IsAdvWatching)
            StopGame();
        else if (focus && !_fullScreenAdv.IsAdvWatching)
            ResumeGame();

        Debug.Log(focus + " " + _fullScreenAdv.IsAdvWatching);
    }
}
