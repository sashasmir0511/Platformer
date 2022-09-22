using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float TimeScale = 0.2f;
    private float _startFixedDeltaTime;

    void Start()
    {
        _startFixedDeltaTime = Time.fixedDeltaTime;
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Time.timeScale = TimeScale;
        }
        else
        {
            Time.timeScale = 1f;
        }
        Time.fixedDeltaTime = Time.timeScale * _startFixedDeltaTime;
    }

    private void OnDestroy()
    {
        Time.fixedDeltaTime = _startFixedDeltaTime;
    }
}
