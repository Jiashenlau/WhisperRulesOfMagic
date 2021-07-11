using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Spells : MonoBehaviour
{
    public Transform rightHandTransform;
    public Hand rightHand;

    public GameObject[] spellObjects;

    public void Fireball()
    {
        var spell = Instantiate(spellObjects[0], rightHandTransform.position, rightHandTransform.rotation);
        rightHand.AttachObject(spell, GrabTypes.Grip);

        Debug.Log("Fireball Spawned");
    }
}
