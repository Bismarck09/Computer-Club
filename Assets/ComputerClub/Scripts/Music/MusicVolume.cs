using UnityEngine;
using UnityEngine.UI;

public class MusicVolume : MonoBehaviour
{
    [SerializeField] private Slider _volumeSlider;

    private AudioSource _backgroundMusic;

    private void Awake()
    {
        _backgroundMusic = GetComponent<AudioSource>();

        if (PlayerPrefs.HasKey("volume"))
        {
            _volumeSlider.value = PlayerPrefs.GetFloat("volume");
            ChangeVolume();
        }
    }

    public void ChangeVolume()
    {
        _backgroundMusic.volume = _volumeSlider.value;
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat("volume", _volumeSlider.value);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat("volume", _volumeSlider.value);
    }
}
