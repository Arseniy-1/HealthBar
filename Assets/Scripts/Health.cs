using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    public event Action HealthChanged;

    [field: SerializeField, Min(1)] public int MaxHealth { get; private set; }

    public float CurrentHealthPoint { get; private set; }

    private void Awake()
    {
        CurrentHealthPoint = MaxHealth;
    }

    public void Heal(int amount)
    {
        if (amount <= 0)
            return;

        if (CurrentHealthPoint + amount >= MaxHealth)
        {
            CurrentHealthPoint = MaxHealth;
            HealthChanged?.Invoke();
            return;
        }

        CurrentHealthPoint += amount;
        HealthChanged?.Invoke();
    }

    public void TakeDamage(int amount)
    {
        if (amount <= 0)
            return;

        CurrentHealthPoint -= amount;

        if (CurrentHealthPoint <= 0)
        {
            Destroy(gameObject);
            CurrentHealthPoint = 0;
        }

        HealthChanged?.Invoke();
    }
}
