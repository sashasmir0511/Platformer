using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth: MonoBehaviour
{
    public int Health = 1;
    public UnityEvent EventOnTakeDamage;
    public UnityEvent EventOnDie;


    public void TakeDamage(int Damage)
    {
        Health -= Damage;
        EventOnTakeDamage.Invoke();
        if (Health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        EventOnDie.Invoke();
    }
}
