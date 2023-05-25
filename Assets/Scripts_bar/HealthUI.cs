using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthUI : MonoBehaviour
{
    [SerializeField] private Health _health;
    
    private Slider _healthSlider;

    private void Awake()
    {
        _healthSlider= GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _health.HealthChanged += UpdateHealthUI;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= UpdateHealthUI;
    }

    private void Start()
    {
        _healthSlider.value = _health.HealthNormalized;
    }

    private void UpdateHealthUI(object sender, float healthNormalized)
    {
        Debug.Log(healthNormalized);
        _healthSlider.DOValue(healthNormalized, 1f);
    }
}
