using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 10f;
    public float lifetime = 5f;

    private Transform target;

    void Start()
    {
        // Cerca il Player per inseguirlo
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            target = playerObj.transform;
        }

        // Distruggi il proiettile dopo un certo tempo
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        if (target == null) return;

        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player colpito!");

            // Se vuoi infliggere danno:
            /*
            PlayerHealth hp = other.GetComponent<PlayerHealth>();
            if (hp != null) hp.TakeDamage(damage);
            */

            Destroy(gameObject);
        }
    }
}