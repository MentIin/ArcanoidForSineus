using System.Collections;
using CodeBase.Logic.Player;
using UnityEngine;

namespace CodeBase.Logic
{
    public class GameManager : MonoBehaviour
    {
        public int Lives = 3;

        [SerializeField] private GameObject _looseScreen;
        [SerializeField] private GameObject _winScreen;
        
        [SerializeField] private GameObject _ballPrefab;
        [SerializeField] private ParticleSystem WinParticles;
        public int Left;
        private void Start()
        {
            Left = FindObjectsOfType<Platform>().Length;
        }

        private void Update()
        {
            if (Left == 0)
            {
                Left = -1;
                StartCoroutine(Win());
            }
        }

        private IEnumerator Win()
        {
            WinParticles.Play();

            Death death = FindObjectOfType<Ball>().GetComponent<Death>();
            death.Platform = true;
            death.Die();
            
            yield return new WaitForSeconds(2f);
            _winScreen.SetActive(true);
        }

        public void BallDied()
        {
            Lives -= 1;
            if (Lives <= 0)
            {
                _looseScreen.SetActive(true);
            }
            else
            {
                GameObject instantiate = Instantiate(_ballPrefab);
                Transform playerTrans = FindObjectOfType<PlayerMovement>().transform;
                playerTrans.position = new Vector3(playerTrans.position.x, -4.5f, 0f);
                instantiate.transform.position = playerTrans.position +
                                                 new Vector3(0f, .5f, 0f);
            }
        }
    }
}