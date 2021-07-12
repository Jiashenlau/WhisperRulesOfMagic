using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceShardScript : MonoBehaviour
{
    public GameController controller;

    public GameObject iceShard;
    public GameObject icePrefab;
    public float damage = 10;

    private ParticleSystem iceParticles;

    private void Awake()
    {
        if (iceShard == null)
        {
            iceShard = this.gameObject;
        }

        if (icePrefab != null)
        {
            iceParticles = icePrefab.GetComponent<ParticleSystem>();
        }
    }

    private void Start()
    {
        controller = FindObjectOfType<GameController>();
    }

    private void Update()
    {
        if (!controller.isRightGripping)
        {
            Destroy(gameObject);
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log(other.name);

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
