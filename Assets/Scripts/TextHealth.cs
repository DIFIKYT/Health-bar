using TMPro;
using UnityEngine;

public class TextHealth : HealthView
{
    [SerializeField] private TMP_Text _text;

    protected override void View(float currentHealth)
    {
        _text.text = $"{_health.CurrentHealth}/{_health.MaxHealth}";
    }
}