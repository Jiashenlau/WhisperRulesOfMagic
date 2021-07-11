using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public bool isRightGripping = false;
    public bool isSpellHeld = false;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (SteamVR_Actions.default_GrabGrip.GetStateDown(SteamVR_Input_Sources.RightHand))
        {
            isRightGripping = true;
            //Debug.Log("Right Gripped");
        }
        else if (SteamVR_Actions.default_GrabGrip.GetStateUp(SteamVR_Input_Sources.RightHand))
        {
            isRightGripping = false;
            //Debug.Log("Right Loose");
        }

        Debug.LogFormat("Right Hand Grip: {0} || SpellHeld: {1}", isRightGripping, isSpellHeld);
    }
}
