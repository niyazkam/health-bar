using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private float _barChangeTime;
    
    private Slider _healthSlider;

    private void Awake()
    {
        _healthSlider= GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _health.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= OnHealthChanged;
    }

    private void Start()
    {
        _healthSlider.value = _health.HealthNormalized;
    }

    private void OnHealthChanged(float healthNormalized)
    {
        Debug.Log(healthNormalized);
        _healthSlider.DOValue(healthNormalized, _barChangeTime);
    }
}
