using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PricesOfObjects : MonoBehaviour
{
    [SerializeField] GameObject[] _placesForPurchase;

    private PriceOfObject[] _priceOfObjects;

    public static PricesOfObjects Instance;

    private void Awake()
    {
        Instance = this;

        _priceOfObjects = new PriceOfObject[_placesForPurchase.Length];
        for (int i = 0; i < _priceOfObjects.Length; i++)
        {
            _priceOfObjects[i] = _placesForPurchase[i].GetComponent<PriceOfObject>();
        }
    }

    public PriceOfObject[] GetPricesOfObjects()
    {
        return _priceOfObjects;
    }

    public void Init(PriceOfObjectData data)
    {
        for (int i = 0; i < _priceOfObjects.Length; i++)
        {
            if (data.Id == _priceOfObjects[i].Id)
                _priceOfObjects[i].Init(data);
        }
    }
}
