using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public event EventHandler<float> HealthChanged;

    [SerializeField] private int _maxHealth;

    private int _health = 0;

    private void Awake()
    {
        _health = _maxHealth;
    }

    public float HealthNormalized => (float)_health / _maxHealth;

    public void ChangeHealth(int health)
    {
        _health = Mathf.Clamp(_health + health, 0, _maxHealth);
        HealthChanged?.Invoke(this, HealthNormalized);
    }
}
