using CodeBase.Logic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private Portal _other;


    private Ball _ball;
    private bool _prepared;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (_prepared)
        {
            _prepared = false;
            return;
        }
        if (col.TryGetComponent(out _ball))
        {
            _other.Prepare();
            col.transform.position = _other.transform.position;
        }
    }

    public void Prepare()
    {
        _prepared = true;
    }
}
