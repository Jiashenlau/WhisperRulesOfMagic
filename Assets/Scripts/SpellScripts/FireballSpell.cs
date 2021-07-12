using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSpell : MonoBehaviour
{
    public GameObject fireball;
    public GameObject firePrefab;
    public float damage = 50;

    private ParticleSystem fireParticles;

    private void Awake()
    {
        if (fireball == null)
        {
            fireball = this.gameObject;
        }

        if (firePrefab != null)
        {
            fireParticles = firePrefab.GetComponent<ParticleSystem>();
        }

        //Destroy(gameObject, 10f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            var enemy = other.GetComponent<ZombieAI>();

            if (enemy != null)
            {
                enemy.ZombieTakeDamage(damage);
            }

            Debug.Log("Hit: " + other.name);

            fireParticles.Stop();
            Destroy(firePrefab, 5);
            firePrefab.transform.parent = null;

            Destroy(this.gameObject);
        }

        if (other.CompareTag("Collider"))
        {
            Debug.Log("Hit: " + other.name);

            fireParticles.Stop();
            Destroy(firePrefab, 5);
            firePrefab.transform.parent = null;

            Destroy(this.gameObject);
        }
    }
}
