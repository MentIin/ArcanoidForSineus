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
            _ball.Direction = RotateVector(_ball.Direction, Random.Range(-30f, 30f));
        }
    }

    public void Prepare()
    {
        _prepared = true;
    }
    public Vector2 RotateVector(Vector2 v, float angle)
    {
        angle = angle * Mathf.Deg2Rad;
        float _x = v.x*Mathf.Cos(angle) - v.y*Mathf.Sin(angle);
        float _y = v.x*Mathf.Sin(angle) + v.y*Mathf.Cos(angle);
        return new Vector2(_x,_y);  
    }
}
