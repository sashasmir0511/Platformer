using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Activator : MonoBehaviour
{
    public List<ActivateByDistance> ObjectsToActivate = new List<ActivateByDistance>();
    public Transform PlayerTransform;

    public UnityEvent EventOnWin;

    void Update()
    {
        for (int i = 0; i < ObjectsToActivate.Count; i++)
        {
            if (PlayerTransform)
            {
                ObjectsToActivate[i].CheckDistance(PlayerTransform.position);
            }
        }
        if (ObjectsToActivate.Count == 0) EventOnWin.Invoke();

    }
}
