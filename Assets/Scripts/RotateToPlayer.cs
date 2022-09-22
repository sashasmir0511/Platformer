using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPlayer : MonoBehaviour
{
    public float RotationSpeed = 5f;
    public Vector3 LeftEuler;
    public Vector3 RightEuler;
    

    private Transform _playerTransform;

    void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMove>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetEuler;
        if (_playerTransform && transform.position.x < _playerTransform.position.x)
            targetEuler = RightEuler;
        else
            targetEuler = LeftEuler;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(targetEuler), Time.deltaTime * RotationSpeed);
    }
}
