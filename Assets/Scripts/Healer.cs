using UnityEngine;
using UnityEngine.UI;

public class Healer : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Button _button;
    [SerializeField] private int _healAmount = 50;

    private void OnEnable()
    {
        _button.onClick.AddListener(Heal);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Heal);
    }

    private void Heal()
    {
        _player.GetComponent<Health>().Heal(_healAmount);
    }
}
