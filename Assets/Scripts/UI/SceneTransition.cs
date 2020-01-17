using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private AnimationCurve curve;

    private Image img;

	void Start ()
    {
        img = GetComponent<Image>();
        StartCoroutine(FadeInAnimation());
    }

    public void FadeOut(int buildIndex)
    {
        StartCoroutine(FadeOutAnimation(buildIndex));
    }

    private IEnumerator FadeInAnimation()
    {
        float t = 1;
        Color fadeColor = new Color(0, 0, 0);

        while (t > 0)
        {
            t -= Time.deltaTime;
            SetImageColor(t, fadeColor);

            yield return null;
        }
    }

    private IEnumerator FadeOutAnimation(int buildIndex)
    {
        float t = 0;
        Color fadeColor = new Color(0, 0, 0);

        while (t < 1)
        {
            t += Time.deltaTime;
            SetImageColor(t, fadeColor);

            yield return null;
        }

        SceneManager.LoadScene(buildIndex);
    }

    private void SetImageColor(float t, Color fadeColor)
    {
        fadeColor.a = curve.Evaluate(t);
        img.color = fadeColor;
    }
}
