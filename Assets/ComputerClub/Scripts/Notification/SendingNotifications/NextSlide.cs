using DG.Tweening;
using UnityEngine;

public class NextSlide : MonoBehaviour
{
    private GameObject _currentSlide;

    public void SwitchSlide(GameObject slide)
    {
        if (_currentSlide != null)
            TurnOffSlides(_currentSlide);

        _currentSlide = slide;
        TurnOnSlides(_currentSlide);
    }

    private void TurnOnSlides(GameObject slide)
    {
        slide.SetActive(true);
        slide.transform.DOScale(1, 0.3f).From(0);
    }

    private void TurnOffSlides(GameObject slide)
    {
        slide.SetActive(false);
    }
}
