using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
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
        _healthBar.value = currentHealth;
    }
}