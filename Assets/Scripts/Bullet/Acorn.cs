using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acorn : MonoBehaviour
{
    public Vector3 Velocity;
    public float MaxRotationSpeed;
    public float TimeDestroy = 4f;

    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddRelativeForce(Velocity, ForceMode.VelocityChange);
        _rigidbody.angularVelocity = new Vector3(
            Random.Range(-MaxRotationSpeed, MaxRotationSpeed),
            Random.Range(-MaxRotationSpeed, MaxRotationSpeed),
            Random.Range(-MaxRotationSpeed, MaxRotationSpeed)
        );
        Destroy(gameObject, TimeDestroy);
    }
}
