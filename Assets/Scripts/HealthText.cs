using TMPro;
using UnityEngine;

public class HealthText : HealthView
{
    [SerializeField] private TextMeshProUGUI _healthView;

    protected override void ShowHealth()
    {
        float amount = Health.CurrentHealthPoint;
        _healthView.text = amount.ToString();
    }
}
