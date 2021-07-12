using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBlastScript : MonoBehaviour
{
    public GameObject waterBlast;
    public GameObject waterPrefab;
    public float damage = 10;

    private ParticleSystem waterParticles;

    private void Awake()
    {
        if (waterBlast == null)
        {
            waterBlast = this.gameObject;
        }

        if (waterPrefab != null)
        {
            waterParticles = waterPrefab.GetComponent<ParticleSystem>();
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
                enemy.ChangeZombieSpeed(0.5f);
            }

            Debug.Log("Hit: " + other.name);

            waterParticles.Stop();
            Destroy(waterPrefab, 5);
            waterPrefab.transform.parent = null;

            Destroy(this.gameObject);
        }

        if (other.CompareTag("Collider"))
        {
            Debug.Log("Hit: " + other.name);

            waterParticles.Stop();
            Destroy(waterPrefab, 5);
            waterPrefab.transform.parent = null;

            Destroy(this.gameObject);
        }
    }
}
