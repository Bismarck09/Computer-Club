using UnityEngine;

public class VisitorMoveAnimation : MonoBehaviour
{
    private const string MoveAnimationName = "IsWalking";

    [SerializeField] private Animator[] _animator;

    private VisitorMovement _movement;

    private void Awake()
    {
        _movement = GetComponent<VisitorMovement>();
    }

    private void Update()
    {
        SwitchAnimation();
    }

    private void SwitchAnimation()
    {
        if (_movement.IsMoving)
            SwitchAllAnimators(true);
        else
            SwitchAllAnimators(false);
    }

    private void SwitchAllAnimators(bool IsMoving)
    {
        foreach (var animator in _animator)
        {
            animator.SetBool(MoveAnimationName, IsMoving);
        }
    }
}
