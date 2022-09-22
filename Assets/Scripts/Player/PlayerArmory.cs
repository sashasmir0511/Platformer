using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmory : MonoBehaviour
{
    public Gun[] Guns;
    public int IndexCurrentGun = 0;

    private void Start()
    {
        DeactivateGuns();
        TakeGunByIndex(IndexCurrentGun);
    }

    public void TakeGunByIndex(int gunIndex)
    {
        Guns[IndexCurrentGun].Deactivate();
        Guns[gunIndex].Activate();
        IndexCurrentGun = gunIndex;
    }

    public void DeactivateGuns()
    {
        for (int i = 0; i < Guns.Length; i++)
        {
            Guns[i].Deactivate();
        }
    }

    public void AddBullet(int gunIndex, int numberOfBullet)
    {
        Guns[gunIndex].AddBullet(numberOfBullet);
    }
}
