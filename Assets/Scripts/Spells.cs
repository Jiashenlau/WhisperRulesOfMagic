using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Spells : MonoBehaviour
{
    public GameController controller;
    public Transform rightHandTransform;
    public Hand rightHand;

    public Transform skySpawn;

    public GameObject[] spellObjects;

    private void Start()
    {
        controller = FindObjectOfType<GameController>();
    }

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
    public void Quake()
    {
        var spell = Instantiate(spellObjects[4], controller.currentLookingPoint, new Quaternion(0, controller.mainCam.transform.rotation.y, 0, controller.mainCam.transform.rotation.w));
        //rightHand.AttachObject(spell, GrabTypes.Grip);

        Debug.Log("Quake Spawned");
    }

    public void AirPush()
    {
        var spell = Instantiate(spellObjects[5], rightHandTransform.position, rightHandTransform.rotation);
        rightHand.AttachObject(spell, GrabTypes.Grip);

        Debug.Log("AirPush Spawned");
    }

    public void Bomb()
    {
        var spell = Instantiate(spellObjects[6], rightHandTransform.position, rightHandTransform.rotation);
        rightHand.AttachObject(spell, GrabTypes.Grip);

        Debug.Log("Bomb Spawned");
    }
}
