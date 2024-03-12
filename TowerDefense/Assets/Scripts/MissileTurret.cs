using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileTurret : Turret
{
    [SerializeField] GameObject missilePrefab;
    [SerializeField] Transform missileOutTransform;
    [SerializeField] float nextAttackTime;

    protected override void Update()
    {
        GetCurrentEnemy();
        
        if (Time.time > nextAttackTime)
        {
            if (currentEnemy != null)
            {
                for (int i = 0; i < 3; i++)
                {
                    Attack();
                }
            }
            
            nextAttackTime = Time.time + 2;
        }
    }

    void Attack()
    {
        GameObject instance = Instantiate(missilePrefab, missileOutTransform.position, Quaternion.identity);
        Missile currentMissile = instance.GetComponent<Missile>();
        currentMissile.SetEnemyAndDamage(currentEnemy, damage);
    }
}
