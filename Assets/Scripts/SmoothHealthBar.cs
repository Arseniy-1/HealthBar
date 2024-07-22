using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SmoothHealthBar : HealthView
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private float _smoothDecreaseDuration = 0.5f;

    protected override void ShowHealth()
    {
        StartCoroutine(SmoothHealthChanging());
    }

    private IEnumerator SmoothHealthChanging()
    {
        float elapsedTime = 0f;
        float previousValue = _healthBar.value;

        while (elapsedTime < _smoothDecreaseDuration)
        {
            elapsedTime += Time.deltaTime;
            float normalizedPosition = elapsedTime / _smoothDecreaseDuration;
            float intermediateValue = Mathf.MoveTowards(previousValue, _health.CurrentHealthPoint / _health.MaxHealth, normalizedPosition);

            _healthBar.value = intermediateValue;

            yield return null;
        }
    }
}
