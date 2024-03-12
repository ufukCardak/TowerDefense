using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            GameManager.Instance.EnqueuEnemyPool(gameObject);
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        health = 100;
    }
}
