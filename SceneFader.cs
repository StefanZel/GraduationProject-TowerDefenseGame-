using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneFader : MonoBehaviour
{
    public Image img;
    public AnimationCurve curve;

    void Start()
    {
        StartCoroutine(FadeIN());
    
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }


    IEnumerator FadeIN()
    {
        float t = 1f;

        while (t > 0f)
        {
            t -= Time.deltaTime * 1f;
            float a = curve.Evaluate(t);
            img.color = new Color (0f, 0f, 0f, a);
            yield return 0;
        }

    }
    IEnumerator FadeOut(string scene)
    {
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * 1f;
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }

        SceneManager.LoadScene(scene);
    }
}
