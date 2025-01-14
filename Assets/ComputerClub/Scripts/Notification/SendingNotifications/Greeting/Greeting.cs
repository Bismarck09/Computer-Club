using UnityEngine;

public class Greeting : MonoBehaviour
{
    [SerializeField] private GameObject _backgroundNotification;
    [SerializeField] private GameObject _resume;
    [SerializeField] private GameObject[] _slides;

    private NextSlide _nextSlide;

    private int _currentSlide;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("firstOpen"))
        {
            _nextSlide = GetComponent<NextSlide>();

            _backgroundNotification.SetActive(true);
            _resume.SetActive(true);

            EnableGreeting();
        }
    }

    private void Update()
    {
        if (!PlayerPrefs.HasKey("firstOpen") && Input.GetMouseButtonDown(0) && _currentSlide != _slides.Length - 1)
        {
            _currentSlide++;
            EnableGreeting();
        }
    }

    private void EnableGreeting()
    {
        if (CheckLastSlide(_currentSlide, _slides.Length))
            return;

        _nextSlide.SwitchSlide(_slides[_currentSlide]);
        
    }

    private bool CheckLastSlide(int currentSlide, int numberOfSlide)
    {
        if (currentSlide == numberOfSlide)
        {
            _nextSlide.SwitchSlide(_slides[currentSlide]);
            _resume.SetActive(false);

            return true;
        }

        return false;
    }
}
