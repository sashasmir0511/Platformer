using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public float Speed = 8;
    public float TimeDestroy = 4f;


    void Start()
    {
        transform.rotation = Quaternion.identity;
        PlayerMove Player = FindObjectOfType<PlayerMove>();
        if (Player)
        {
            Transform PlayerTransform = Player.transform;
            Vector3 toPlayer = (PlayerTransform.position - transform.position).normalized;

            Rigidbody.velocity = toPlayer * Speed;
            Destroy(gameObject, TimeDestroy);
        }
        
    }
}
