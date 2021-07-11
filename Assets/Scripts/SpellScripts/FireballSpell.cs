using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSpell : MonoBehaviour
{
    public GameObject fireball;

    private void Awake()
    {
        if (fireball == null)
        {
            fireball = this.gameObject;
        }

        Destroy(gameObject, 10f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Hit: " + other.name);

            Destroy(this.gameObject);
        }

        if (other.CompareTag("Collider"))
        {
            Debug.Log("Hit: " + other.name);

            Destroy(this.gameObject);
        }
    }
}
