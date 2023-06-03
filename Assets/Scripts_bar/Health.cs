using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    private int _health = 0;

    public float HealthNormalized => (float)_health / _maxHealth;

    public event UnityAction<float> HealthChanged;

    private void Awake()
    {
        _health = _maxHealth;
    }

    public void ChangeHealth(int health)
    {
        _health = Mathf.Clamp(_health + health, 0, _maxHealth);
        HealthChanged?.Invoke(HealthNormalized);
    }
}
