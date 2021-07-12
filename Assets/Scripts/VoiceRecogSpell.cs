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
        actions.Add("firefall", Meteor);
        actions.Add("gravity", Meteor);
        actions.Add("fall", Meteor);

        //WaterBlast Words
        actions.Add("waterblast", WaterBlast);
        actions.Add("waterball", WaterBlast);
        actions.Add("water", WaterBlast);
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
        if (controller.playerMana >= 10)
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
        if (controller.playerMana >= 50)
        {
            spells.Meteor();
            controller.ModifyMana(50);
        }
    }
    #endregion
}
