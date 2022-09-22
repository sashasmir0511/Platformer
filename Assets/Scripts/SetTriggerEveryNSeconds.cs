using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTriggerEveryNSeconds : MonoBehaviour
{
    public float AttackPeriod = 7f;
    public Animator Animator;
    public string NameTrigger = "Attack";
    private float _timer;


    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > AttackPeriod)
        {
            _timer = 0f;
            Animator.SetTrigger(NameTrigger);
        }
    }
}
