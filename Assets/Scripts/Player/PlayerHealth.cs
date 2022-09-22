using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public int Health = 8;
    public int MaxHealth = 10;
    public HealthUI HealthUI;

    public UnityEvent EventOnTakeDamage;
    public UnityEvent EventOnAddHealth;
    public UnityEvent EventOnDie;

    private bool _invulnerable = false;

    private void Start()
    {
        HealthUI.Setup(MaxHealth);
        HealthUI.DisplayHealth(Health);
    }

    public void TakeDamage(int Damage)
    {
        if (_invulnerable == false)
        {
            Health -= Damage;
            HealthUI.DisplayHealth(Health);
            if (Health <= 0)
            {
                Health = 0;
                Die();
            }
            _invulnerable = true;
            Invoke("StopInvulnerable", 1f);
            EventOnTakeDamage.Invoke();
        }
    }

    void StopInvulnerable()
    {
        _invulnerable = false;
    }

    public void AddHealth(int healthValue)
    {
        Health += healthValue;
        EventOnAddHealth.Invoke();
        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }
        HealthUI.DisplayHealth(Health);
    }

    public void Die()
    {
        EventOnDie.Invoke();
        Destroy(gameObject);
        //Debug.Log("You Lose");
    }
}
