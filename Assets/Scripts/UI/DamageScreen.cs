using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageScreen : MonoBehaviour
{
    public Image DamageScreenImage;

    public void StarEffect()
    {
        StartCoroutine(ShowEffect());
    }

    public IEnumerator ShowEffect()
    {
        DamageScreenImage.enabled = true;
        for (float t = 1f; t > 0; t-=Time.deltaTime * 2f)
        {
            DamageScreenImage.color = new Color(1f, 0f, 0f, t);
            yield return null;
        }
        DamageScreenImage.enabled = false;
    }
}
