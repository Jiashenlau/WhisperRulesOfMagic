using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public int _playerHealth = 10;
    public int playerHealth
    {
        get
        {
            return _playerHealth;
        }
        set
        {
            _playerHealth = value;

            if (playerHealth <= 0)
            {
                PlayerDeath();
            }
        }
    }

    public int _playerMana = 100;
    public int playerMana
    {
        get
        {
            return _playerMana;
        }
        set
        {
            _playerMana = value;
        }
    }

    public int _zombiesKilled = 0;
    public int zombiesKilled
    {
        get
        {
            return _zombiesKilled;
        }
        set
        {
            _zombiesKilled = value;

            if (zombieSpawner != null)
            {
                zombieSpawner.SpawnTimerChanger();
            }
        }
    }

    public int healthRegenRate = 1;
    public int manaRegenRate = 10;

    public Camera mainCam;
    public RaycastHit hit;
    public Vector3 currentLookingPoint;
    public ZombieSpawner zombieSpawner;
    public Transform rayOrb;
    public Transform player;
    public Transform respawnPoint;

    public bool isRightGripping = false;
    public bool isSpellHeld = false;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        StartCoroutine(nameof(HealthRegen));
        StartCoroutine(nameof(ManaRegen));

        zombieSpawner = FindObjectOfType<ZombieSpawner>();
    }

    private void OnApplicationQuit()
    {
        StopAllCoroutines();
    }

    // Update is called once per frame
    void Update()
    {
        if (SteamVR_Actions.default_GrabGrip.GetStateDown(SteamVR_Input_Sources.RightHand))
        {
            isRightGripping = true;
        }
        else if (SteamVR_Actions.default_GrabGrip.GetStateUp(SteamVR_Input_Sources.RightHand))
        {
            isRightGripping = false;
        }

        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit))
        {
            Debug.DrawRay(mainCam.transform.position, mainCam.transform.forward * 1000, Color.green);

            currentLookingPoint = hit.point;
            rayOrb.position = currentLookingPoint;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            playerHealth -= 100;
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            zombiesKilled += 10;
        }

        Debug.LogFormat("Right Hand Grip: {0} || SpellHeld: {1}", isRightGripping, isSpellHeld);
    }

    private IEnumerator HealthRegen()
    {
        while (true)
        {
            if (playerHealth < 10)
            {
                playerHealth += healthRegenRate;
            }

            if (playerHealth > 10)
            {
                playerHealth = 10;
            }

            yield return new WaitForSeconds(5);

            yield return null;
        }
    }

    private IEnumerator ManaRegen()
    {
        while (true)
        {
            if (playerMana < 100)
            {
                playerMana += manaRegenRate;
            }

            if (playerMana > 100)
            {
                playerMana = 100;
            }

            yield return new WaitForSeconds(1f);

            yield return null;
        }
    }

    public void ModifyHealth(int healthToChange)
    {
        playerHealth -= healthToChange;
    }

    public void ModifyMana(int manaToChange)
    {
        playerMana -= manaToChange;
    }

    public void ZombiesKilledModify(int killed)
    {
        zombiesKilled += killed;
    }

    public void PlayerDeath()
    {
        zombiesKilled = 0;
        playerHealth = 10;
        playerMana = 100;

        player.position = respawnPoint.position;
        zombieSpawner.KillAllZombies();
    }
}
