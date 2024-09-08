using System;
using CodeBase.Logic;
using TMPro;
using UnityEngine;

namespace CodeBase.UI
{
    public class HealthText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        private GameManager _gameManager;

        private void Start()
        {
            _gameManager = FindObjectOfType<GameManager>();
        }

        private void LateUpdate()
        {
            _text.text = "lives: " + _gameManager.Lives;
        }
    }
}