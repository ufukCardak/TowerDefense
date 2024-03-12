using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunTurret : Turret
{
    [SerializeField] GameObject bulletTraicePrefab;
    [SerializeField] Transform bulletOutTransform;
    [SerializeField] float nextAttackTime;
    [SerializeField] LayerMask enemyLayerMask;
    [SerializeField] RaycastHit2D hit;

    protected override void Update()
    {
        base.Update();
        

        if (Time.time > nextAttackTime)
        {
            if (currentEnemy != null)
            {
                StartCoroutine(Attack());
            }
            nextAttackTime = Time.time + 0.5f;
        }
    }

    IEnumerator Attack()
    {
        for (int i = 0; i < 3; i++)
        {
            hit = Physics2D.Raycast(bulletOutTransform.position, bulletOutTransform.transform.up, 4, enemyLayerMask);

            if (hit.collider != null)
            {
                if (currentEnemy == null)
                {
                    yield break;
                }
                LineRenderer bulletTraice = Instantiate(bulletTraicePrefab, bulletOutTransform.transform.position, Quaternion.identity).GetComponent<LineRenderer>();
                Destroy(bulletTraice.gameObject,0.5f);
                bulletTraice.enabled = true;
                bulletTraice.SetPosition(0, bulletOutTransform.transform.position);
                bulletTraice.SetPosition(1, currentEnemy.transform.position + new Vector3(Random.Range(-0.15f, 0.15f), Random.Range(-0.15f, 0.15f), 0));

                EnemyHealth enemyHealth = hit.collider.gameObject.GetComponent<EnemyHealth>();
                enemyHealth.TakeDamage(damage);
            }

            yield return new WaitForSeconds(0.3f);
        }
    }
}
