using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowToTarget : MonoBehaviour
{
    public Transform Target;
    public float LerpRate;

    // Update is called once per frame
    void Update()
    {
        if (Target)
            transform.position = Vector3.Lerp(transform.position, Target.position, Time.deltaTime * LerpRate);
    }
}
