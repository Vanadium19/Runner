using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBox : MonoBehaviour
{
    [SerializeField] private float _healthPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
            player.Heal(_healthPoint);

        Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
