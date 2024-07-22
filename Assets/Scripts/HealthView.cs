using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthView;
    [SerializeField] private Health _health;
    [SerializeField] private Slider _healthBar;
    [SerializeField] private float _smoothDecreaseDuration = 0.5f;

    private void OnEnable()
    {
        _health.HealthChanged += ShowHealth;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= ShowHealth;
    }

    private void Update()
    {

    }

    private void ShowHealth()
    {
        float amount = _health.CurrentHealthPoint;
        _healthView.text = amount.ToString();

        StartCoroutine(SmoothHealthChanging());
        //_healthBar.value =  Mathf.MoveTowards(_healthBar.value, _health.CurrentHealthPoint / _health.MaxHealth, 0.1f);
    }

    private IEnumerator SmoothHealthChanging()
    {
        float elapsedTime = 0f;
        float previousValue = _healthBar.value;

        while (elapsedTime < _smoothDecreaseDuration)
        {
            elapsedTime += Time.deltaTime;
            float normalizedPosition = elapsedTime / _smoothDecreaseDuration;
            float intermediateValue = Mathf.MoveTowards(previousValue, _health.CurrentHealthPoint/_health.MaxHealth, normalizedPosition);

            _healthBar.value = intermediateValue;

            yield return null;
        }
    }
}
