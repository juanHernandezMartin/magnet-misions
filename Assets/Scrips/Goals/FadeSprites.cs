using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeSprites
{
    static private float fadeTime = 0.1f;

    static public IEnumerator FadeIn(SpriteRenderer sprRenderer)
    {
        Color tmp = sprRenderer.color;
        float lerpValue = 0;

        while (sprRenderer.color.a > 0)
        {
            lerpValue += Time.deltaTime;
            tmp.a = Mathf.Lerp(0, 1, lerpValue / fadeTime);
            sprRenderer.color = tmp;
            yield return null;
        }
    }

    static public IEnumerator FadeOut(SpriteRenderer sprRenderer)
    {
        Color tmp = sprRenderer.color;
        tmp.a = 0;
        sprRenderer.color = tmp;
        float lerpValue = 0;

        while (sprRenderer.color.a < 1)
        {
            lerpValue += Time.deltaTime;
            tmp.a = Mathf.Lerp(0, 1, lerpValue / fadeTime);
            sprRenderer.color = tmp;
            yield return null;
        }
    }
}
