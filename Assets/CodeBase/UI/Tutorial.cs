using System;
using UnityEngine;

namespace CodeBase.UI
{
    public class Tutorial : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Destroy(this.gameObject);
            }
        }
    }
}