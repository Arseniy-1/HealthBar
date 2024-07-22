using UnityEngine;
using UnityEngine.UI;

public class Damager : MonoBehaviour
{
    [SerializeField] private Health _playerHealth;
    [SerializeField] private Button _button;
    [SerializeField] private int _damageAmount = 50;

    private void OnEnable()
    {
        _button.onClick.AddListener(TakeDamage);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(TakeDamage);
    }

    private void TakeDamage()
    {
        _playerHealth.TakeDamage(_damageAmount);
    }
}
