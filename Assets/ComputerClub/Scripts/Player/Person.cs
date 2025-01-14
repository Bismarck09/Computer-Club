using UnityEngine;

public class Person : MonoBehaviour
{
    [SerializeField] private GameObject _man;
    [SerializeField] private GameObject _woman;
    [SerializeField] private MainPerson _mainPerson;

    public int PersonNumber;

    public static Person Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void LoadMainPerson(int personNumber)
    {
        PersonNumber = personNumber;

        if (PersonNumber == 1)
            _mainPerson.ChooseMainPerson(_man);
        else
            _mainPerson.ChooseMainPerson(_woman);
    }

    public void SetPersonNumber(int personNumber)
    {
        PersonNumber = personNumber;
    }
}
