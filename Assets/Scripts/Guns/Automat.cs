using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Automat : Gun
{
    [Header("Automat")]
    public int NumberOfBullets = 30;
    public Text BulletsText;
    public PlayerArmory PlayerArmory;

    private void Start()
    {
        UpdateText();
    }

    public override void Shot()
    {
        if (NumberOfBullets != 0)
        {
            base.Shot();
            NumberOfBullets -= 1;
            UpdateText();
        }
        if (NumberOfBullets <= 0)
        {
            PlayerArmory.TakeGunByIndex(0);
        }
    }

    public void UpdateText()
    {
        BulletsText.text = NumberOfBullets.ToString();
    }

    public override void Activate()
    {
        base.Activate();
        BulletsText.enabled = true;
    }

    public override void Deactivate()
    {
        base.Deactivate();
        BulletsText.enabled = false;
    }

    public override void AddBullet(int numberOfBullet)
    {
        NumberOfBullets = numberOfBullet;
        UpdateText();
        PlayerArmory.TakeGunByIndex(1);
    }
}
