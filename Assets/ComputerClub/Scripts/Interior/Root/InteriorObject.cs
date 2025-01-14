using UnityEngine;

public class InteriorObject : MonoBehaviour
{
    [SerializeField] private int _id;

    private bool _isPurchased;

    public int ID => _id;
    public bool IsPurchased => _isPurchased;

    public void EnableInteriorObject()
    {
        gameObject.SetActive(true);
        _isPurchased = true;
    }
}
