using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootHealth : MonoBehaviour
{
    public int Health;

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth PlayerHealth = other.attachedRigidbody.GetComponent<PlayerHealth>();
        if (PlayerHealth)
        {
            PlayerHealth.AddHealth(Health);
            Destroy(gameObject);
        }
    }
}
