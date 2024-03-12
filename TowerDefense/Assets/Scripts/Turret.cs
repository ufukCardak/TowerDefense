using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] List<Enemy> enemies = new List<Enemy>();

    [SerializeField] protected Enemy currentEnemy;
    [SerializeField] protected float damage;

    [SerializeField] float rotationSpeed = 200f;

    protected virtual void Update()
    {
        GetCurrentEnemy();
        RotateToEnemy();
    }

    protected void GetCurrentEnemy()
    {
        if (enemies.Count <= 0)
        {
            currentEnemy = null;
            return;
        }

        currentEnemy = enemies[0];
    }

    protected void RotateToEnemy()
    {
        if (currentEnemy == null)
        {
            return;
        }

        Vector3 target = currentEnemy.transform.position;

        float angle = Mathf.Atan2(target.y - transform.position.y,target.x - transform.position.x) * Mathf.Rad2Deg - 90f;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        /*Vector3 targetPos = currentEnemy.transform.position - transform.position;
        float angle = Vector3.SignedAngle(transform.up, targetPos, transform.forward);
        transform.Rotate(0,0,angle);*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy newEnemy = collision.GetComponent<Enemy>();
            enemies.Add(newEnemy);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemies.Contains(enemy))
            {
                enemies.Remove(enemy);
            }
        }
    }
}
