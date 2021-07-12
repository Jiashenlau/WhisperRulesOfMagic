using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameController controller;
    public List<SpawnPoint> spawnPoints = new List<SpawnPoint>();
    public List<Transform> spawnPointPos = new List<Transform>();
    public List<ZombieAI> zombieAi = new List<ZombieAI>();

    public GameObject zombiePrefab;
    public float timeToSpawn = 5;
    public float zombieSpeedModifier = 0f;

    private void Awake()
    {
        spawnPoints = FindObjectsOfType<SpawnPoint>().ToList();

        foreach (SpawnPoint point in spawnPoints)
        {
            spawnPointPos.Add(point.transform);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType<GameController>();
        StartCoroutine(nameof(Spawner));
    }

    public void SpawnTimerChanger()
    {
        switch (controller.zombiesKilled)
        {
            case 0:
                timeToSpawn = 2.5f;
                zombieSpeedModifier = 0.5f;
                break;

            case 5:
                timeToSpawn = 2.5f;
                break;

            case 10:
                timeToSpawn = 2f;
                break;

            case 20:
                timeToSpawn = 1.5f;
                zombieSpeedModifier = 1.5f;
                break;

            case 40:
                timeToSpawn = 1f;
                zombieSpeedModifier = 2f;
                break;

            case 80:
                zombieSpeedModifier = 3f;
                break;

            case 100:
                zombieSpeedModifier = 5f;
                break;

            case 200:
                zombieSpeedModifier = 10f;
                break;

            default:
                Debug.LogError("Zombies Killed Invalid");
                break;
        }
    }

    public IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeToSpawn);

            if (CheckForMaxZombie())
            {
                var zombie = Instantiate(zombiePrefab, spawnPointPos[GetRandomSpawnPoint()]);
                zombie.GetComponent<ZombieAI>().ChangeZombieSpeed(zombieSpeedModifier);
                zombie = null;
            }

            yield return null;
        }
    }

    private int GetRandomSpawnPoint()
    {
        var rand = Random.Range(0, spawnPointPos.Count);

        return rand;
    }

    bool CheckForMaxZombie()
    {
        zombieAi = FindObjectsOfType<ZombieAI>().ToList();

        if (zombieAi.Count <= 50)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void KillAllZombies()
    {
        zombieAi = FindObjectsOfType<ZombieAI>().ToList();

        foreach (ZombieAI zombies in zombieAi)
        {
            if (zombies != null)
            {
                Destroy(zombies.gameObject);
            }
        }
    }
}
