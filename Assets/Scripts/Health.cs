using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [field: SerializeField, Min(1)] public int MaxHealth { get; private set; }

    public event Action<float, float> HealthChanged;
    public event Action Died;

    public float CurrentHealthPoint { get; private set; }

    private void Awake()
    {
        CurrentHealthPoint = MaxHealth;
    }

    public void Heal(int amount)
    {
        if (amount <= 0)
            return;

        CurrentHealthPoint = Mathf.Clamp(CurrentHealthPoint + amount, 0, MaxHealth);

        HealthChanged?.Invoke(CurrentHealthPoint, MaxHealth);
    }

    public void TakeDamage(int amount)
    {
        if (amount <= 0)
            return;

        CurrentHealthPoint = Mathf.Clamp(CurrentHealthPoint - amount, 0, MaxHealth);
        
        if (CurrentHealthPoint == 0)
            Died.Invoke();

        HealthChanged?.Invoke(CurrentHealthPoint, MaxHealth);
    }
}
