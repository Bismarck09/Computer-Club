using UnityEngine;

public class Interior : MonoBehaviour
{
    [SerializeField] private GameObject[] _allInterior;

    private InteriorObject[] _interiorObjects;

    public static Interior Instance;

    private void Awake()
    {
        Instance = this;

        _interiorObjects = new InteriorObject[_allInterior.Length];
        for (int i = 0; i < _interiorObjects.Length; i++)
        {
            _interiorObjects[i] = _allInterior[i].GetComponent<InteriorObject>();
        }
    }

    public InteriorObject[] GetAllInterior()
    {
        return _interiorObjects;
    }

    public float GetCurrentInteriorBonus()
    {
        float bonus = 1;

        for (int i = 0; i < _interiorObjects.Length; i++)
        {
            if (_interiorObjects[i].IsPurchased)
                bonus += _interiorObjects[i].Bonus;
        }

        return bonus;
    }

    public void Init(InteriorData interiorData)
    {
        if (interiorData.IsPurchased == true)
            _interiorObjects[interiorData.Id - 1].EnableInteriorObject();
    }
}
