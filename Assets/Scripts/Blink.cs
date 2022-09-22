using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    public Renderer[] Renderers;

    public void StartBlink()
    {
        StartCoroutine(ShowBlink());
    }

    public IEnumerator ShowBlink()
    {
        for (float t = 0f; t < 1; t += Time.deltaTime * 2f)
        {
            for (int i = 0; i < Renderers.Length; i++)
            {
                for (int j = 0; j < Renderers[i].materials.Length; j++)
                {
                    Renderers[i].materials[j].SetColor("_EmissionColor", new Color(Mathf.Sin(t * 30) * 0.5f + 0.5f, 0f, 0f, 0f));
                }
            }
            yield return null;
        }
    }
}
