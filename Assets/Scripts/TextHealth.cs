using TMPro;
using UnityEngine;

public class TextHealth : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Health _health;

    private void Start()
    {
        View(_health.CurrentHealth);
    }

    private void OnEnable()
    {
        _health.HealthChanged += View;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= View;
    }

    private void View(float currentHealth)
    {
        _text.text = $"{_health.CurrentHealth}/{_health.MaxHealth}";
    }
}