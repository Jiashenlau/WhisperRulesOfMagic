using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellNamePopUp : MonoBehaviour
{
    public GameObject spellName;
    public Text spellNameText;

    public string textToShow = "default";

    // Start is called before the first frame update
    void Start()
    {
        spellNameText = spellName.GetComponent<Text>();
    }

    public void ShowTextPopUp(string spellNameToShow)
    {
        textToShow = spellNameToShow;

        spellName.SetActive(false);

        StopAllCoroutines();
        StartCoroutine(nameof(TextPopUpAndDisappear));
    }

    private IEnumerator TextPopUpAndDisappear()
    {
        spellNameText.text = textToShow;
        spellName.SetActive(true);

        yield return new WaitForSecondsRealtime(1);

        for (float i = 5; i >= 0; i -= Time.deltaTime)
        {
            var colorAlpha = spellNameText.color;
            colorAlpha = new Color(colorAlpha.r, colorAlpha.g, colorAlpha.b, colorAlpha.a - Time.unscaledDeltaTime);
            spellNameText.color = colorAlpha;

            yield return null;
        }

        spellName.SetActive(false);
        spellNameText.color = new Color(spellNameText.color.r, spellNameText.color.g, spellNameText.color.b, 150);
        yield break;
    }
}
