using UnityEngine;
using UnityEngine.UI;

public class HealthBar : HealthView
{
    [SerializeField] protected Slider HealthBarView;

    protected override void ShowHealth()
    {
        HealthBarView.value = Health.CurrentHealthPoint / Health.MaxHealth;
    }
}
