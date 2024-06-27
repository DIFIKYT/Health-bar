using UnityEngine;

public abstract class HealthView : MonoBehaviour
{
    [SerializeField] protected Health _health;

    protected void OnEnable()
    {
        _health.HealthChanged += View;
    }

    protected void OnDisable()
    {
        _health.HealthChanged -= View;
    }

    protected void Start()
    {
        View(_health.CurrentHealth);
    }

    protected abstract void View(float amount);
}