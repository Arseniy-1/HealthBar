using UnityEngine;

[RequireComponent(typeof(Health))]

public class Player : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.Died += MakeDeath;
    }

    private void OnDisable()
    {
        _health.Died -= MakeDeath;
    }

    private void MakeDeath()
    {
        Destroy(gameObject);
    }
}
