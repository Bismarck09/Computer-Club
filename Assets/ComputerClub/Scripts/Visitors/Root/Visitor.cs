using UnityEngine;

public class Visitor : MonoBehaviour
{
    private GameObject _visitor;

    public GameObject GetVisitor()
    {
        return _visitor;
    }

    public void SetVisitor(GameObject visitor)
    {
        if (_visitor == null)
            _visitor = visitor;
    }
}
