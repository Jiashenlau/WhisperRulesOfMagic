using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuakeScript : MonoBehaviour
{
    public float damage = 10;

    private void Start()
    {
        Destroy(gameObject, 6);
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Rock Hit:" + other.name);

        if (other.CompareTag("Enemy"))
        {
            var enemy = other.GetComponent<ZombieAI>();

            if (enemy != null)
            {
                enemy.ZombieTakeDamage(damage);
                enemy.ChangeZombieSpeed(1.5f);
            }
        }
    }
}
