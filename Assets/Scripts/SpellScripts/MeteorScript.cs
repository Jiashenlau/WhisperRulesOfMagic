using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorScript : MonoBehaviour
{
    public GameController controller;

    public GameObject meteor;
    public GameObject meteorPrefab;
    public float damage = 100;
    public Vector3 hitpoint;
    public float speed = 0.5f;
    public float explosionRadius = 100;
    public GameObject hitPointMarker;

    public ParticleSystem meteorExplosion;
    private ParticleSystem meteorParticles;
    int layerMask = 1 << 3;

    private void Awake()
    {
        if (meteor == null)
        {
            meteor = this.gameObject;
        }

        if (meteorPrefab != null)
        {
            meteorParticles = meteorPrefab.GetComponent<ParticleSystem>();
        }

        Destroy(gameObject, 20f);
    }

    private void Start()
    {
        controller = FindObjectOfType<GameController>();
        hitpoint = controller.currentLookingPoint;
        StartCoroutine(nameof(GoToPoint));

        hitPointMarker.transform.parent = null;
        hitPointMarker.transform.position = hitpoint;
    }

    private IEnumerator GoToPoint()
    {
        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, hitpoint, speed);

            if (transform.position == hitpoint)
            {
                DestroyMeteor();
            }

            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            DestroyMeteor();
        }

        if (other.CompareTag("Collider"))
        {
            Debug.Log("Hit: " + other.name);

            DestroyMeteor();
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
        int numColliders = Physics.OverlapSphereNonAlloc(hitpoint, explosionRadius, hitColliders, layerMask);

        for (int i = 0; i < numColliders; i++)
        {
            Debug.Log(hitColliders[i].name);

            if (hitColliders[i].GetComponent<ZombieAI>())
            {
                hitColliders[i].GetComponent<ZombieAI>().ZombieTakeDamage(damage);
            }
        }
    }

    void DestroyMeteor()
    {
        Destroy(hitPointMarker);

        meteorParticles.Stop();
        meteorExplosion.Play();
        Destroy(meteorPrefab, 5);
        Destroy(meteorExplosion.gameObject, 5);
        meteorExplosion.gameObject.transform.parent = null;
        meteorPrefab.transform.parent = null;
        StopAllCoroutines();
        HitEnemyInArea();

        Destroy(this.gameObject, 0.2f);
    }
}
