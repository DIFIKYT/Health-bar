using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField, Min(1)] private int _maxHealth;
    [SerializeField] private Button _reduceHealthButton;
    [SerializeField] private Button _restoreHealthButton;

    private int _�urrentHealth;
    private bool IsAlive => _�urrentHealth > 0;

    private void OnEnable()
    {
        _reduceHealthButton.onClick.AddListener(Reduce);
        _restoreHealthButton.onClick.AddListener(Restore);
    }

    private void OnDisable()
    {
        _reduceHealthButton.onClick.RemoveAllListeners();
        _restoreHealthButton.onClick.RemoveAllListeners();
    }

    private void Awake()
    {
        _�urrentHealth = _maxHealth;
    }

    private void Reduce()
    {
        int Amount = 20;

        if (Amount <= 0)
            return;

        _�urrentHealth -= Amount;

        if (IsAlive == false)
            _�urrentHealth = 0;
    }

    private void Restore()
    {
        int Amount = 20;

        if (Amount <= 0)
            return;

        _�urrentHealth = Mathf.Clamp(_�urrentHealth + Amount, 0, _maxHealth);
    }
}