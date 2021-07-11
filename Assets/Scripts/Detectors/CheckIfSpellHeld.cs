using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfSpellHeld : MonoBehaviour
{
    public GameController controller;

    private void Start()
    {
        if (controller == null)
        {
            controller = FindObjectOfType<GameController>();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other != null && other.CompareTag("Spells"))
        {
            controller.isSpellHeld = true;
        }
        else if (other == null && !other.CompareTag("Spells"))
        {
            controller.isSpellHeld = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Spells"))
        {
            controller.isSpellHeld = false;
        }
    }
}
