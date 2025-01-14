using UnityEngine;

public class Walls : MonoBehaviour
{
    [SerializeField] private GameObject _visibleWall;
    [SerializeField] private GameObject _invisibleWall;

    public void EnableVisibleWall()
    {
        _visibleWall.SetActive(true);
        _invisibleWall.SetActive(false);
    }

    public void EnableInvisibleWall()
    {
        _invisibleWall.SetActive(true);
        _visibleWall.SetActive(false);
    }
}
