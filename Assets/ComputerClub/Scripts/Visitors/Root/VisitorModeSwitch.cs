using UnityEngine;

public class VisitorModeSwitch : MonoBehaviour
{
    [SerializeField] private GameObject[] _mainVisitors;

    private Visitor _visitor;

    private void Awake()
    {
        _visitor = GetComponent<Visitor>();
    }

    public void SwitchModeVisitor(bool isActive, GameObject[] sitVisitors)
    {
        for (int i = 0; i < sitVisitors.Length; i++)
        {
            if (_mainVisitors[i] == _visitor.GetVisitor())
            {
                _mainVisitors[i].gameObject.SetActive(isActive);
                sitVisitors[i].gameObject.SetActive(!isActive);
            }
        }
    }
}
