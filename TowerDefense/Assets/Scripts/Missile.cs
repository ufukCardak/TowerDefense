using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    Rigidbody2D rb;
    Enemy currentEnemy;
    float damage;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (currentEnemy != null)
        {
            MoveMissile();
            RotateMissile();
        }

        if (currentEnemy != null && !currentEnemy.gameObject.activeSelf)
        {
            Destroy(gameObject);
        }

    }
    void MoveMissile()
    {
        Vector2 direction = (currentEnemy.transform.position - transform.position).normalized;
        rb.velocity = direction * 5;
    }

    void RotateMissile()
    {
        Vector3 targetPos = currentEnemy.transform.position - transform.position;
        float angle = Vector3.SignedAngle(transform.up, targetPos, transform.forward);
        transform.Rotate(0, 0, angle);
    }
    public void SetEnemyAndDamage(Enemy currentEnemy, float damage)
    {
        this.currentEnemy = currentEnemy;
        this.damage = damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
