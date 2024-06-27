using System;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField, Min(1)] private int _maxAmount;
    [SerializeField] private Button _reduceButton;
    [SerializeField] private Button _restoreButton;

    public event Action<float> Changed;

    private float _currentAmount;
    private int _minRandomValue;
    private int _maxRandomValue;

    public int MaxAmount => _maxAmount;
    public float CurrentAmount => _currentAmount;
    private bool IsAlive => _currentAmount > 0;

    private void Awake()
    {
        _currentAmount = _maxAmount;
        _minRandomValue = 1;
        _maxRandomValue = 50;
    }

    private void OnEnable()
    {
        _reduceButton.onClick.AddListener(OnReduce);
        _restoreButton.onClick.AddListener(OnRestore);
    }

    private void OnDisable()
    {
        _reduceButton.onClick.RemoveAllListeners();
        _restoreButton.onClick.RemoveAllListeners();
    }

    private void OnReduce()
    {
        int amount = UnityEngine.Random.Range(_minRandomValue, _maxRandomValue);

        _currentAmount -= amount;

        if (IsAlive == false)
            _currentAmount = 0;

        Changed?.Invoke(_currentAmount);
    }

    private void OnRestore()
    {
        int amount = UnityEngine.Random.Range(_minRandomValue, _maxRandomValue);

        _currentAmount = Mathf.Clamp(_currentAmount + amount, 0, _maxAmount);

        Changed?.Invoke(_currentAmount);
    }
}