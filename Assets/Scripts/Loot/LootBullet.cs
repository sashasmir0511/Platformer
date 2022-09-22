using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBullet : MonoBehaviour
{
    public int NumberOfBullets;
    public int GunIndex;

    private void OnTriggerEnter(Collider other)
    {
        PlayerArmory playerArmory = other.attachedRigidbody.GetComponent<PlayerArmory>();
        if (playerArmory)
        {
            playerArmory.AddBullet(GunIndex, NumberOfBullets);
            Destroy(gameObject);
        }
    }
}
