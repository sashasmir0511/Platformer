using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageOnCollision : MonoBehaviour
{
    public EnemyHealth EnemyHealth;
    public bool DieOnAnyCollision = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody)
        {
            if (collision.rigidbody.GetComponent<Bullet>())
            {
                EnemyHealth.TakeDamage(1);
            }
        }
        if (DieOnAnyCollision)
        {
            EnemyHealth.TakeDamage(10000);
        }
    }

}
