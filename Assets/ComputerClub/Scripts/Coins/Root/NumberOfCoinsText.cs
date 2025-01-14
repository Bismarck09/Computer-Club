using System.Collections;
using TMPro;
using UnityEngine;

public class NumberOfCoinsText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _numberOfCoinsText;
    [SerializeField] private TextMeshProUGUI _numberAmountCoinsText;
    [SerializeField] private GameObject _numberAmountCoins;

    private CoinsStorage _coinsData;
    private Vector3 _apperanceSize;
    private Vector3 _startAmountCoinsSize;

    private void Awake()
    {
        _coinsData = GetComponent<CoinsStorage>();
        _numberOfCoinsText.text = _coinsData.NumberOfCoins.ToString();

        _apperanceSize = new Vector3(transform.localScale.x + 0.3f, transform.localScale.y + 0.3f, transform.localScale.z);
        _startAmountCoinsSize = _numberAmountCoins.transform.localScale;
    }

    private void OnEnable()
    {
        _coinsData.ChangedNumberOfCoins += ChangeCoinText;
    }

    private void OnDisable()
    {
        _coinsData.ChangedNumberOfCoins -= ChangeCoinText;
    }

    private void ChangeCoinText(string sign, float coins)
    {
        StartCoroutine(EnableAnimationTakeCoins(sign, coins));
    }

    private IEnumerator EnableAnimationTakeCoins(string sign, float coins)
    {
        StartCoroutine(EnableAnimationApperanceText(1, _apperanceSize));
        _numberAmountCoinsText.text = sign + coins.ToString("0.0");

        yield return new WaitForSeconds(0.5f);
        _numberAmountCoins.SetActive(false);
        _numberOfCoinsText.text = _coinsData.NumberOfCoins.ToString("0.0");
    }

    private IEnumerator EnableAnimationApperanceText(float time, Vector3 target)
    {
        _numberAmountCoins.transform.localScale = _startAmountCoinsSize;
        _numberAmountCoins.SetActive(true);

        float Timer = 0;
        Vector3 Base = _numberAmountCoins.transform.localScale;

        while (Timer < time)
        {
            _numberAmountCoins.transform.localScale = Vector3.Lerp(Base, target, Timer / time);
            yield return null;
            Timer += Time.deltaTime;
        }
        _numberAmountCoins.transform.localScale = target;
    }
}
