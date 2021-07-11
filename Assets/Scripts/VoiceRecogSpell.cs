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
        actions.Add("fireball", FireBall);
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

    void FireBall()
    {
        spells.Fireball();
    }
}
