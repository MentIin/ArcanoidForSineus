using System;
using UnityEngine;

namespace CodeBase.Logic.Level
{
    public class PlatformAnimator : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer Renderer;
        [SerializeField] private Gradient Gradient;
        [SerializeField] private int MaxHealth=5;
        [SerializeField] private Platform Platform;


        private void Update()
        {
            Renderer.color = Gradient.Evaluate((float)Platform.Health / MaxHealth);
        }
    }
}