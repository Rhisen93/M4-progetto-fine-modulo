using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float detectionRange = 10f;
    public Transform player;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 1f;

    private float fireCooldown = 0f;

    void Update()
    {
        if (player == null)
            return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            transform.LookAt(player);

            if (fireCooldown <= 0f)
            {
                Shoot();
                fireCooldown = 1f / fireRate;
            }
        }

        fireCooldown -= Time.deltaTime;
    }

    void Shoot()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
