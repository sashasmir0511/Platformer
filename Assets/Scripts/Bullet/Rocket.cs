using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float Speed = 1f;
    public float RotationSpeed = 1f;
    public float TimeDestroy = 4f;

    private Transform _playerTransform;

    void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMove>().transform;
        Destroy(gameObject, TimeDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * Speed * transform.forward;
        if (_playerTransform)
        {
            Vector3 toPlayer = _playerTransform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(toPlayer, Vector3.forward);

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * RotationSpeed);
        }
        
    }
}
