using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    public GameController controller;
    public NavMeshAgent zombieAgent;
    public Transform player;

    public float _zombieHealth;
    public float zombieHealth
    {
        get
        {
            return _zombieHealth;
        }
        set
        {
            _zombieHealth = value;
            CheckForDeath();
        }
    }

    public float _zombieSpeed = 2;
    public float zombieSpeed
    {
        get
        {
            return _zombieSpeed;
        }
        set
        {
            _zombieSpeed = value;
            UpdateZombieSpeed();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType<GameController>();
        player = FindObjectOfType<EmptyPlayer>().transform;

        zombieAgent.speed = zombieSpeed;
    }

    private void Update()
    {
        zombieAgent.SetDestination(player.position);
    }

    public void ChangeZombieSpeed(float speed)
    {
        _zombieSpeed = speed;
        zombieAgent.speed = _zombieSpeed;
    }

    void CheckForDeath()
    {
        if (zombieHealth <= 0)
        {
            StopAllCoroutines();
            controller.ZombiesKilledModify(1);
            Destroy(gameObject, 5);
            gameObject.SetActive(false);
        }
    }

    public void ZombieTakeDamage(float damage)
    {
        zombieHealth -= damage;
    }

    void UpdateZombieSpeed()
    {
        zombieAgent.speed = _zombieSpeed;
    }
}
