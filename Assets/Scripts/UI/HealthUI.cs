using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public GameObject HealthIconPrefab;
    public List<GameObject> HealthIcons;

    public void Setup(int MaxHealth)
    {
        for (int i = 0; i < MaxHealth; i++)
        {
            GameObject newHealthIcon = Instantiate(HealthIconPrefab, transform);
            HealthIcons.Add(newHealthIcon);
        }
    }

    public void DisplayHealth(int HealthCount)
    {
        for (int i = 0; i < HealthIcons.Count; i++)
        {
            if (i < HealthCount) HealthIcons[i].SetActive(true);
            else HealthIcons[i].SetActive(false);
        }
    }
}
