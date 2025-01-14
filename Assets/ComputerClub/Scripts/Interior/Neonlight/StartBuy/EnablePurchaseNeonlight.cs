using UnityEngine;

public class EnablePurchaseNeonlight : MonoBehaviour
{
    [SerializeField] private GameObject[] _neonlightObjects;
    [SerializeField] private AllComputers _allComputers;

    private void Start()
    {
        if (_allComputers.Computers >= 6)
            EnablePurchase();
    }

    public void EnablePurchase()
    {
        for (int i = 0; i < _neonlightObjects.Length; i++)
        {
            PaymentForInteriorObject interiorObject = _neonlightObjects[i].GetComponent<PaymentForInteriorObject>();

            if (!interiorObject.Interior.IsPurchased)
                _neonlightObjects[i].SetActive(true);
        }
    }
}
