using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoDisplay : MonoBehaviour
{
    public GameController controller;
    public TextMeshProUGUI infoText;


    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        infoText.text = "Health: " + controller.playerHealth + "\n" + "Mana: " + controller.playerMana + "\n" + "Zombies Killed: " + controller.zombiesKilled;
    }
}
