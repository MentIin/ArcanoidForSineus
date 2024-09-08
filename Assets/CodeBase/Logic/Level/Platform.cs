using System;
using CodeBase.Logic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public int StartHealth = 1;

    [SerializeField] private Death _death;
    
    
    private int _health;

    public int Health
    {
        get => _health;
    }

    private void Awake()
    {
        _health = StartHealth;
    }


    public void GetDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            _death.Die();
        }
    }
}
