using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Health _health;

    private float _smoothSpeed;
    private float _targetHealth;

    private void Start()
    {
        _targetHealth = _health.CurrentHealth;
        _healthBar.value = _health.CurrentHealth;
        _smoothSpeed = _health.MaxHealth;
}

    private void OnEnable()
    {
        _health.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= OnHealthChanged;
    }

    private void Update()
    {
        _healthBar.value = Mathf.MoveTowards(_healthBar.value, _targetHealth, _smoothSpeed * Time.deltaTime);
    }

    private void OnHealthChanged(float updateHealth)
    {
        _targetHealth = updateHealth;
    }
}