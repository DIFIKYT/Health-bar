using System;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField, Min(1)] private int _maxHealth;
    [SerializeField] private Button _reduceHealthButton;
    [SerializeField] private Button _restoreHealthButton;

    public event Action<float> HealthChanged;

    private float _currentHealth;
    private int _minRandomValue;
    private int _maxRandomValue;

    public int MaxHealth => _maxHealth;
    public float CurrentHealth => _currentHealth;
    private bool IsAlive => _currentHealth > 0;

    private void Awake()
    {
        _currentHealth = _maxHealth;
        _minRandomValue = 1;
        _maxRandomValue = 50;
    }

    private void OnEnable()
    {
        _reduceHealthButton.onClick.AddListener(OnReduce);
        _restoreHealthButton.onClick.AddListener(OnRestore);
    }

    private void OnDisable()
    {
        _reduceHealthButton.onClick.RemoveAllListeners();
        _restoreHealthButton.onClick.RemoveAllListeners();
    }

    private void OnReduce()
    {
        int Amount = UnityEngine.Random.Range(_minRandomValue, _maxRandomValue);

        _currentHealth -= Amount;

        if (IsAlive == false)
            _currentHealth = 0;

        HealthChanged?.Invoke(_currentHealth);
    }

    private void OnRestore()
    {
        int Amount = UnityEngine.Random.Range(_minRandomValue, _maxRandomValue);

        _currentHealth = Mathf.Clamp(_currentHealth + Amount, 0, _maxHealth);

        HealthChanged?.Invoke(_currentHealth);
    }
}