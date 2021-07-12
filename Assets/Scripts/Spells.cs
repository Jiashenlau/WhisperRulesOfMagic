using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Spells : MonoBehaviour
{
    public Transform rightHandTransform;
    public Hand rightHand;

    public Transform skySpawn;

    public GameObject[] spellObjects;

    public void Fireball()
    {
        var spell = Instantiate(spellObjects[0], rightHandTransform.position, rightHandTransform.rotation);
        rightHand.AttachObject(spell, GrabTypes.Grip);

        Debug.Log("Fireball Spawned");
    }

    public void WaterBlast()
    {
        var spell = Instantiate(spellObjects[1], rightHandTransform.position, rightHandTransform.rotation);
        rightHand.AttachObject(spell, GrabTypes.Grip);

        Debug.Log("WaterBlast Spawned");
    }

    public void Meteor()
    {
        var spell = Instantiate(spellObjects[2], skySpawn.position, skySpawn.rotation);

        Debug.Log("Meteor Spawned");
    }

    public void IceSpears()
    {
        var spell = Instantiate(spellObjects[3], rightHandTransform.position, rightHandTransform.rotation);
        rightHand.AttachObject(spell, GrabTypes.Grip);

        Debug.Log("Ice Spear Spawned");
    }

    public void AirPush()
    {
        var spell = Instantiate(spellObjects[4], rightHandTransform.position, rightHandTransform.rotation);
        rightHand.AttachObject(spell, GrabTypes.Grip);

        Debug.Log("AirPush Spawned");
    }
}
