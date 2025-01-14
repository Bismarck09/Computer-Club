using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;

    Vector3 moveUsualDirection => new Vector3(_joystick.Direction.x, 0, _joystick.Direction.y);
    Vector3 moveInverseDirection => new Vector3(-_joystick.Direction.y, 0, _joystick.Direction.x);

    public bool IsMovement => _joystick.Direction != Vector2.zero;
    public bool IsInverseMovement = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (IsMovement)
            Move();
        else
            _rigidbody.velocity = Vector3.zero;
    }

    private void Move()
    {
        Vector3 moveDirection = IsInverseMovement ? moveInverseDirection : moveUsualDirection;

        transform.LookAt(transform.position + moveDirection);
        _rigidbody.velocity = moveDirection * _speed;
    }
}
