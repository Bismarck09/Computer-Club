using UnityEngine;

public class InteriorObject : MonoBehaviour
{
    [SerializeField] private int _id;
    [SerializeField] private float _bonus;

    private bool _isPurchased;

    public int ID => _id;
    public bool IsPurchased => _isPurchased;
    public float Bonus => _bonus;

    public void EnableInteriorObject()
    {
        gameObject.SetActive(true);
        _isPurchased = true;
    }
}
