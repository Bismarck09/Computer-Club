using UnityEngine;
using UnityEngine.UI;

public class UIRating : MonoBehaviour
{
    [SerializeField] private Image _ratingImage;

    // Т.К. зона FillAmount от 0 до 1, а мой рейтинг от 1 до 5, я делю рейтинг на 5.
    public void ChangeRating(float newRating)
    {
        _ratingImage.fillAmount = newRating / 5;
    }
}
