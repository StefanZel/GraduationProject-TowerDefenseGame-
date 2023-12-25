using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoundsSurvived : MonoBehaviour
{
    //public Text roundsText; -For a normal text type, Not the TextMesh Pro
    public TMP_Text canvasText;

    void OnEnable()
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {

        canvasText.text = "0";

        int round = 0;

        yield return new WaitForSeconds(.7f);

        while (round < PlayerStats.Rounds)
        {
            round++;
            canvasText.text = round.ToString();

            yield return new WaitForSeconds(.05f);       
        }
    }

}
