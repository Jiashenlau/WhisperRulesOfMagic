using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceScript : MonoBehaviour
{
    public GameObject airBall;
    public GameObject airPrefab;
    public float damage = 10;

    private ParticleSystem airParticles;

    private void Awake()
    {
        if (airBall == null)
        {
            airBall = this.gameObject;
        }

        if (airPrefab != null)
        {
            airParticles = airPrefab.GetComponent<ParticleSystem>();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            var enemy = collision.transform.GetComponent<ZombieAI>();

            if (enemy != null)
            {
                enemy.ZombieTakeDamage(damage);
            }

            Debug.Log("Hit: " + collision.transform.name);

            //airParticles.Stop();
            //Destroy(airPrefab, 5);
            //airPrefab.transform.parent = null;

            Destroy(this.gameObject, 10);
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Enemy"))
    //    {
    //        var enemy = other.GetComponent<ZombieAI>();

    //        if (enemy != null)
    //        {
    //            enemy.ZombieTakeDamage(damage);
    //        }

    //        Debug.Log("Hit: " + other.name);

    //        airParticles.Stop();
    //        Destroy(airPrefab, 5);
    //        airPrefab.transform.parent = null;

    //        Destroy(this.gameObject);
    //    }

    //    if (other.CompareTag("Collider"))
    //    {
    //        Debug.Log("Hit: " + other.name);

    //        airParticles.Stop();
    //        Destroy(airPrefab, 5);
    //        airPrefab.transform.parent = null;

    //        Destroy(this.gameObject);
    //    }
    //}
}
