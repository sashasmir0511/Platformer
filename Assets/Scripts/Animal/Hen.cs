using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hen : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public float Speed = 3f;
    public float TimeToReachSpeed = 1f;

    private Transform _playerTransform;

    void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMove>().transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if  (_playerTransform)
        {
            Vector3 toPlayer = (_playerTransform.position - transform.position).normalized;
            Vector3 Force = Rigidbody.mass * (toPlayer * Speed - Rigidbody.velocity) / TimeToReachSpeed;

            Rigidbody.AddForce(Force);
        }
        
    }
}
