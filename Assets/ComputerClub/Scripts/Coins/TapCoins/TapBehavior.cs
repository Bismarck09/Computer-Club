using UnityEngine;

public class TapBehavior : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void ReactOnTap()
    {
        _audioSource.Play();

    }    
}
