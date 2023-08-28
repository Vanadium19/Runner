using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Image _image;
    [SerializeField] private float _delay;

    private Coroutine _healthChanger;

    private void OnEnable()
    {
        _player.HealthChanged += ChangeHealthBar;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= ChangeHealthBar;
    }

    private void ChangeHealthBar(float health)
    {
        StopChangingHealthBar();
        StartChangingHealthBar(health);
    }

    private void StartChangingHealthBar(float health)
    {
        _healthChanger = StartCoroutine(ChangeHealthBarTo(health));
    }

    private void StopChangingHealthBar()
    {
        if (_healthChanger != null)
            StopCoroutine(_healthChanger);
    }

    private IEnumerator ChangeHealthBarTo(float health)
    {
        float startValue = _image.fillAmount;
        float targetValue = health / _player.MaxHealth;
        float elapsed = 0;

        while (_image.fillAmount != targetValue)
        {
            _image.fillAmount = Mathf.Lerp(startValue, targetValue, elapsed / _delay);
            elapsed += Time.deltaTime;
            yield return null;
        }
    }
}
