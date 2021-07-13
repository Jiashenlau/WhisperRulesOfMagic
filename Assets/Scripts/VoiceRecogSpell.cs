using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;


public class VoiceRecogSpell : MonoBehaviour
{
    public GameController controller;
    public SpellNamePopUp spellNamePopUp;
    public Spells spells;

    public KeywordRecognizer keyword;
    public Dictionary<string, Action> actions = new Dictionary<string, Action>();

    private void Awake()
    {
        //fireball words
        actions.Add("fireball", FireBall);
        actions.Add("fire", FireBall);

        //Meteor Words
        actions.Add("meteor", Meteor);
        //actions.Add("firefall", Meteor);
        actions.Add("gravity", Meteor);
        actions.Add("fall", Meteor);

        //WaterBlast Words
        actions.Add("waterblast", WaterBlast);
        actions.Add("waterball", WaterBlast);
        actions.Add("water", WaterBlast);
        actions.Add("whatthe", WaterBlast);
        actions.Add("whater", WaterBlast);

        //IceSpear Words
        actions.Add("icespear", IceSpears);
        actions.Add("icespears", IceSpears);
        actions.Add("icelance", IceSpears);
        actions.Add("icelances", IceSpears);
        actions.Add("ice", IceSpears);
        actions.Add("icicle", IceSpears);
        actions.Add("nice", IceSpears);

        //Quake Words
        actions.Add("quake", Quake);
        actions.Add("earth", Quake);
        actions.Add("rise", Quake);
        actions.Add("earthlance", Quake);
        actions.Add("earthquake", Quake);
        actions.Add("earthspear", Quake);

        //AirPush Words
        actions.Add("airpush", AirPush);
        actions.Add("air", AirPush);
        actions.Add("push", AirPush);
        actions.Add("force", AirPush);
        actions.Add("back", AirPush);

        //Bomb Words
        actions.Add("bomb", Bomb);
        actions.Add("explode", Bomb);
        actions.Add("explosion", Bomb);
        actions.Add("grenade", Bomb);
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType<GameController>();
        spellNamePopUp = FindObjectOfType<SpellNamePopUp>();
        spells = FindObjectOfType<Spells>();

        keyword = new KeywordRecognizer(actions.Keys.ToArray());
        keyword.OnPhraseRecognized += SpellRecognized;
        keyword.Start();
    }

    void SpellRecognized(PhraseRecognizedEventArgs spellName)
    {
        Debug.Log(spellName.text);

        if (!controller.isSpellHeld && controller.isRightGripping)
        {
            actions[spellName.text].Invoke();
            spellNamePopUp.ShowTextPopUp(spellName.text);
        }
    }

    #region SpellsToTrigger
    void FireBall()
    {
        if (controller.playerMana >= 30)
        {
            spells.Fireball();
            controller.ModifyMana(10);
        }
    }

    void WaterBlast()
    {
        if (controller.playerMana >= 20)
        {
            spells.WaterBlast();
            controller.ModifyMana(20);
        }
    }

    void Meteor()
    {
        if (controller.playerMana >= 80)
        {
            spells.Meteor();
            controller.ModifyMana(80);
        }
    }

    void IceSpears()
    {
        if (controller.playerMana >= 100)
        {
            spells.IceSpears();
            controller.ModifyMana(100);
        }
    }

    void Quake()
    {
        if (controller.playerMana >= 80)
        {
            spells.Quake();
            controller.ModifyMana(80);
        }
    }

    void AirPush()
    {
        if (controller.playerMana >= 30)
        {
            spells.AirPush();
            controller.ModifyMana(30);
        }
    }

    void Bomb()
    {
        if (controller.playerMana >= 50)
        {
            spells.Bomb();
            controller.ModifyMana(50);
        }
    }
    #endregion
}
