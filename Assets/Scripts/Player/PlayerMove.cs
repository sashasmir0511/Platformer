using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Transform ColliderTransform;
    public Rigidbody Rigidbody;
    public float MoveSpeed;
    public float JumpSpeed;
    public float Friction;
    public float MaxSpeed;
    public bool Grounded;

    private int _jumpFrameCounter;

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.S) || Grounded == false)
        {
            ColliderTransform.localScale = Vector3.Lerp(ColliderTransform.localScale, new Vector3 (1f, 0.5f, 1f), Time.deltaTime * 15f);
        }
        else
        {
            ColliderTransform.localScale = Vector3.Lerp(ColliderTransform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 15f);
        }

        if (Grounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    public void Jump()
    {
        Rigidbody.AddForce(0f, JumpSpeed, 0f, ForceMode.VelocityChange);
        _jumpFrameCounter = 0;
    }

    private void FixedUpdate()
    {
        float speedMultiplier = 1f;

        if (!Grounded)
        {
            speedMultiplier = 0.2f;
            if ((Rigidbody.velocity.x > MaxSpeed && Input.GetAxis("Horizontal") > 0)
                || (Rigidbody.velocity.x < -MaxSpeed && Input.GetAxis("Horizontal") < 0))
            {
                speedMultiplier = 0f;
            }
        }
        
        Rigidbody.AddForce(Input.GetAxis("Horizontal") * MoveSpeed * speedMultiplier, 0f, 0f, ForceMode.VelocityChange);
        if (Grounded)
        {
            Rigidbody.AddForce(-Rigidbody.velocity.x * Friction, 0f, 0f, ForceMode.VelocityChange);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * 15f);
        }
            

        _jumpFrameCounter += 1;
        if (_jumpFrameCounter == 2)
        {
            Rigidbody.freezeRotation = false;
            Rigidbody.AddRelativeTorque(0f, 0f, 10f, ForceMode.VelocityChange);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        float angle = Vector3.Angle(collision.contacts[0].normal, Vector3.up);
        if (angle <= 45)
        {
            Grounded = true;
            Rigidbody.freezeRotation = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Grounded = false;
    }
}
