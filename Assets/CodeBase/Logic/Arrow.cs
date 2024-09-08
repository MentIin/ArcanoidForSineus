using System;
using UnityEngine;

namespace CodeBase.Logic
{
    public class Arrow : MonoBehaviour
    {
        private void Update()
        {
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPoint = new Vector3(worldPoint.x, worldPoint.y, 0f);
            transform.right = worldPoint -
                              transform.position;
            transform.Rotate(0f, 0f, 0);
        }
    }
}