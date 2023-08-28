using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _maxHeath;
    
    public event UnityAction Died;
    public event UnityAction<float> HealthChanged;

    private float _currentHealth;

    public float MaxHealth => _maxHeath;

    public void Start()
    {
        _currentHealth = _maxHeath;
    }

    public void ApplyDamage(float damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth);

        if (_currentHealth <= 0)
            Die();
    }

    public void Heal(float healthPoint)
    {
        _currentHealth += healthPoint;
        _currentHealth = _currentHealth < _maxHeath ? _currentHealth : _maxHeath;
        HealthChanged?.Invoke(_currentHealth);
    }

    private void Die()
    {
        Died?.Invoke();
    }
}
