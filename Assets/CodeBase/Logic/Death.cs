using UnityEngine;

namespace CodeBase.Logic
{
    public class Death : MonoBehaviour
    {
        public bool Platform = false;
        public SpriteRenderer Renderer;
        public GameObject DeathParticles;
        public void Die()
        {
            GameObject instantiate = Instantiate(DeathParticles, transform.position, Quaternion.identity);
            ParticleSystem.MainModule mainModule = instantiate.GetComponent<ParticleSystem>().main;
            mainModule.startColor = Renderer.color;
            Destroy(instantiate, 7f);
            
            Destroy(this.gameObject);

            if (Platform)
            {
                FindObjectOfType<GameManager>().Left--;
            }
            else
            {
                FindObjectOfType<GameManager>().BallDied();
            }
        }
    }
}