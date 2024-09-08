using CodeBase.Infrastructure.Data;
using UnityEngine;

namespace CodeBase.Logic.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private MinMaxRange<float> MoveRange;
        private void Update()
        {
            if (Time.timeScale == 0f) return;
            float x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;

            if (x < MoveRange.Min) x = MoveRange.Min;
            if (x > MoveRange.Max) x = MoveRange.Max;
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
        }
    }
}
