using System;
using UnityEngine;

namespace CodeBase.Logic
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField] private Ball _ball;
        private void Awake()
        {
            Time.timeScale = 0f;
        }


        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _ball.Direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) -
                                  _ball.transform.position;
                Time.timeScale = 1f;
                Destroy(this.gameObject);
            }
        }
    }
}