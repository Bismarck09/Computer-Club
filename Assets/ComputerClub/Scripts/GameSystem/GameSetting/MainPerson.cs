using UnityEngine;

public class MainPerson : MonoBehaviour
{
    [SerializeField] private PlayerMoveAnimation _moveAnimation;

    private GameObject _mainPerson;

    public GameObject Person => _mainPerson;

    public void ChooseMainPerson(GameObject person)
    {
        _mainPerson = person;
        _mainPerson.SetActive(true);

        if(_mainPerson.TryGetComponent(out Animator animator))
            _moveAnimation.SetAnimator(animator);
    }

}
