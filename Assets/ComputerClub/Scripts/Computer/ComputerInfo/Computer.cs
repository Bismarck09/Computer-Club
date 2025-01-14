using UnityEngine;

public class Computer : MonoBehaviour
{
    [SerializeField] private int _priceForHour;
    [SerializeField] private int _id;

    public int Id => _id;
    public int PriceForHour => _priceForHour;
}
