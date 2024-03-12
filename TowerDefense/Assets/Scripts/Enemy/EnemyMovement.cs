using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] float moveSpeed = 2f;

    Transform target;
    int pathIndex;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void Start()
    {
        target = Waypoint.Instance.points[pathIndex];
    }

    private void Update()
    {
        if (Vector2.Distance(target.position,transform.position) <= 0.1f)
        {
            pathIndex++;

            if (pathIndex == Waypoint.Instance.points.Length)
            {
                Destroy(gameObject);
                return;
            }
            else
            {
                target = Waypoint.Instance.points[pathIndex];
            }
        }

        if (target.position.x > transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;
    }

    private void OnDisable()
    {
        pathIndex = 0;
        target = Waypoint.Instance.points[pathIndex];
    }
}
