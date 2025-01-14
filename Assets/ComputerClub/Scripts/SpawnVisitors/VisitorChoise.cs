using UnityEngine;

public class VisitorChoise : MonoBehaviour
{
    [SerializeField] private GameObject[] _visitors;
    [SerializeField] private string[] _visitorNames;

    private Visitor _visitor;

    private void Awake()
    {
        _visitor = GetComponent<Visitor>();

        ChoiseVisitor();
    }

    private void ChoiseVisitor()
    {
        int visitorNumber = Random.Range(0, _visitors.Length);

        _visitors[visitorNumber].gameObject.SetActive(true);
        _visitor.SetVisitor(_visitors[visitorNumber]);
    }
}
