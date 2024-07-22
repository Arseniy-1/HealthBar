using UnityEngine;

public abstract class HealthView : MonoBehaviour
{
    [SerializeField] protected Health Health;

    private void OnEnable()
    {
        Health.HealthChanged += ShowHealth;
    }

    private void OnDisable()
    {
        Health.HealthChanged -= ShowHealth;
    }

    protected abstract void ShowHealth();
}
