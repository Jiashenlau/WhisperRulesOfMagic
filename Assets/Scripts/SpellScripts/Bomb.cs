using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameController controller;

    public GameObject bomb;
    public float damage = 100;
    public float explosionRadius = 100;

    public ParticleSystem bombExplosion;
    int layerMask = 1 << 3;

    private void Awake()
    {
        if (bomb == null)
        {
            bomb = this.gameObject;
        }
    }

    private void Start()
    {
        controller = FindObjectOfType<GameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            DestroyBomb();
        }

        if (other.CompareTag("Collider"))
        {
            Debug.Log("Hit: " + other.name);

            DestroyBomb();
        }
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    void HitEnemyInArea()
    {
        int maxColliders = 10;
        Collider[] hitColliders = new Collider[maxColliders];
        int numColliders = Physics.OverlapSphereNonAlloc(transform.position, explosionRadius, hitColliders, layerMask);

        for (int i = 0; i < numColliders; i++)
        {
            Debug.Log(hitColliders[i].name);

            if (hitColliders[i].GetComponent<ZombieAI>())
            {
                hitColliders[i].GetComponent<ZombieAI>().ZombieTakeDamage(damage);
            }
        }
    }

    void DestroyBomb()
    {
        bombExplosion.Play();
        Destroy(bombExplosion.gameObject, 5);
        bombExplosion.gameObject.transform.parent = null;
        StopAllCoroutines();
        HitEnemyInArea();

        Destroy(this.gameObject, 0.2f);
    }
}
