using UnityEngine;

public class HidingWall : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Camera _camera;

    private Walls _invisibleWall;
    private Walls _wall;
    private Ray _ray;

    private void Update()
    {
        CheckWall();
    }

    //≈сть ли стена между камерой и игроком
    private void CheckWall()
    {
        CreateRayToTarget();

        if (Physics.Raycast(_ray, out RaycastHit hit))
        {
            _wall = hit.collider.gameObject.GetComponentInParent<Walls>();

            if ( _wall != null)
            {
                if (_invisibleWall != null)
                    _invisibleWall.EnableVisibleWall();

                _invisibleWall = _wall;
                _wall.EnableInvisibleWall();
            }
            else if (_invisibleWall != null)
            {
               _invisibleWall.EnableVisibleWall();
            }
        }
    }

    private void CreateRayToTarget()
    {
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Vector3 worldPoint = _camera.ScreenToWorldPoint(new Vector3(screenCenter.x, screenCenter.y, _camera.nearClipPlane));

        Vector3 directionToTarget = _target.position - worldPoint;
        _ray = new Ray(worldPoint, directionToTarget);
    }
}
