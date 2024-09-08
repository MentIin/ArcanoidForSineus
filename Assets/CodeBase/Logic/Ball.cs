using UnityEngine;

namespace CodeBase.Logic
{
    public class Ball : MonoBehaviour
    {
        public Vector2 Direction;
        public Rigidbody2D Rigidbody;
        public CircleCollider2D Collider2D;

        public LayerMask LayerMask;
        [Space(5)]

        public float Speed = 1f;
        [Space(5)]
        
        [SerializeField]private AudioSource _hitSound;

        private Platform _platform;
        private void FixedUpdate()
        {
            RaycastHit2D hit2D = Physics2D.CircleCast(transform.position,
                Collider2D.radius * transform.localScale.x, Direction, Speed * Time.deltaTime, LayerMask);
            Vector2 moveOffset;
        
            if (hit2D.collider == null)
            {
                moveOffset = Direction.normalized * Speed;
            }
            else
            {
                
                // yes I know I must check collisions with a loop but this is a PROTOTYPE 
                _hitSound.Play();
                _hitSound.pitch = Random.Range(0.8f, 1.2f);
                
                if (hit2D.collider.TryGetComponent(out _platform))
                {
                    _platform.GetDamage(1);
                }
                
                Rigidbody.MovePosition((Vector2) transform.position + Direction.normalized * hit2D.distance);
                Direction = Vector2.Reflect(Direction, hit2D.normal);

                if (hit2D.collider.gameObject.CompareTag("Player"))
                {
                    float width = hit2D.collider.bounds.extents.x;
                    float x = (transform.position.x - hit2D.collider.bounds.center.x) / width;
                    Direction = new Vector2(x, 1f);
                }
                
                moveOffset = Direction.normalized * (Speed - hit2D.distance) + hit2D.normal * 0.1f;
            }
            
            Move(moveOffset);
        }

        private void Move(Vector2 moveOffset)
        {
            
            Rigidbody.MovePosition((Vector2) transform.position + moveOffset * Time.deltaTime);
        }
    }
}
