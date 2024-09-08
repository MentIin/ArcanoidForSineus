using UnityEngine;

namespace CodeBase.Logic
{
    public class Dangerous : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {

            Death death;
            if (other.gameObject.TryGetComponent(out death))
            {
                death.Die();
            }
        }
    }
}
